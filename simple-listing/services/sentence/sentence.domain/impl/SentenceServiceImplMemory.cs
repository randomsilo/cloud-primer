using System;
using System.Collections.Generic;
using System.Linq;
using sentence.domain.model;
using sentence.domain.service;

namespace sentence.domain.impl
{
    public class SentenceServiceImplMemory : ISentenceService
    {
        private List<SentenceEntry> _sentences;

        public SentenceServiceImplMemory()
        {
            _sentences = new List<SentenceEntry>();
        }

        public IEnumerable<SentenceEntry> FetchAll()
        {
            return _sentences.AsEnumerable();
        }

        public SentenceEntry Add(SentenceEntry entry)
        {
            long maxId =_sentences.OrderByDescending(s => s.Id).FirstOrDefault()?.Id ?? 0;
            
            entry.Id = maxId + 1;
            entry.CreatedOn = DateTime.Now;

            _sentences.Add(entry);

            return entry;
        }

        public SentenceEntry Update(SentenceEntry entry)
        {
            var foundEntry = FindById(entry.Id);

            foundEntry.Sentence = entry.Sentence;
            foundEntry.UpdatedOn = DateTime.Now;

            return foundEntry;
        }

        public bool Delete(SentenceEntry entry)
        {
            bool deleted = false;

            var foundEntry = FindById(entry.Id);
            if (foundEntry != null)
            {
                deleted = _sentences.Remove(foundEntry);
            }
    
            return deleted;
        }

        public SentenceEntry FindById(long? id)
        {
            if (id == null)
                throw new ArgumentNullException("Id must be populated");

            if (id <= 0)
                throw new ArgumentNullException("Id must be a positive non-zero number");

            var foundEntry = _sentences.FirstOrDefault(x => x.Id == id);

            if (foundEntry == null)
                throw new KeyNotFoundException("Id was not found.");

            return foundEntry;
        }
    }
}
