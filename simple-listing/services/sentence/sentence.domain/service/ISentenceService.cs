using System;
using System.Collections.Generic;
using System.Linq;
using sentence.domain.model;

namespace sentence.domain.service
{
    public interface ISentenceService
    {
        IEnumerable<SentenceEntry> FetchAll();
        SentenceEntry Add(SentenceEntry entry);
        SentenceEntry Update(SentenceEntry entry);
        bool Delete(SentenceEntry entry);
        SentenceEntry FindById(long? id);
    }
}
