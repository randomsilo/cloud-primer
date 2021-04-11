using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using Npgsql;
using sentence.domain.model;
using sentence.domain.service;

namespace sentence.domain.impl
{
    public class SentenceServiceImplPostgres : ISentenceService
    {
        private string _connectionString;

        public SentenceServiceImplPostgres(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<SentenceEntry> FetchAll()
        {
            IEnumerable<SentenceEntry> sentenceEntries = null;

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                sentenceEntries = connection.Query<SentenceEntry>(
                    @"
                    select 
                        * 
                    from 
                        simple_listing.sentences
                    ");
            }

            return sentenceEntries;
        }

        public SentenceEntry Add(SentenceEntry entry)
        {
            entry.Id = null;
            entry.CreatedOn = DateTime.Now;

            long? newId = null;

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                newId = connection.ExecuteScalar<long>(
                    @"
                    insert into simple_listing.sentences
                    (sentence,createdOn,updatedOn)
                    values
                    (@sentence,@createdOn,@updatedOn) returning Id;
                    ", entry);
                
            }

            if (newId == null || newId <= 0)
                throw new InvalidOperationException("Failed to add record");

            SentenceEntry dbEntry = FindById(newId);

            return dbEntry;
        }

        public SentenceEntry Update(SentenceEntry entry)
        {
            var foundEntry = FindById(entry.Id);

            foundEntry.Sentence = entry.Sentence;
            foundEntry.UpdatedOn = DateTime.Now;

            int rows;

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                rows = connection.Execute(
                    @"
                    update simple_listing.sentences
                        set 
                            sentence = @sentence
                            , createdOn = @createdOn
                            , updatedOn = @updatedOn
                        where
                            id = @id
                    ", foundEntry);
            }

            if (rows <= 0)
                throw new InvalidOperationException("Failed to update record");

            SentenceEntry dbEntry = FindById(entry.Id);

            return dbEntry;
        }

        public bool Delete(SentenceEntry entry)
        {
            bool deleted = false;
            int rows;

            var foundEntry = FindById(entry.Id);
            if (foundEntry != null)
            {
                using (var connection = new NpgsqlConnection(_connectionString))
                {
                    rows = connection.Execute("delete from simple_listing.sentences where id = @id", foundEntry);

                    if (rows == 1)
                    {
                        deleted = true;
                    }
                    else
                    {
                        throw new InvalidOperationException("Failed to delete record");
                    }
                }
            }
    
            return deleted;
        }

        public SentenceEntry FindById(long? id)
        {
            SentenceEntry foundEntry = null;

            if (id == null)
                throw new ArgumentNullException("Id must be populated");

            if (id <= 0)
                throw new ArgumentNullException("Id must be a positive non-zero number");

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                foundEntry = connection.Query<SentenceEntry>(
                    @"
                    select 
                        * 
                    from 
                        simple_listing.sentences
                    where
                        id = @id
                    ",  new {Id = id}).FirstOrDefault();
            }

            if (foundEntry == null)
                throw new KeyNotFoundException("Id was not found.");

            return foundEntry;
        }
    }
}
