using System;

namespace sentence.domain.model
{
    public class SentenceEntry
    {
        public long? Id { get; set; }
        public string Sentence { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
