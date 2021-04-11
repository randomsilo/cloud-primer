using System;
using System.Collections.Generic;
using System.Linq;
using sentence.domain.model;
using sentence.domain.service;
using sentence.domain.impl;
using Xunit;

namespace sentence.test
{
    public class ImplMemoryTest
    {
        [Fact]
        public void BasicCrud()
        {
            ISentenceService service = new SentenceServiceImplMemory();

            var sample = new SentenceEntry() { Sentence = "Sample" };

            var addReturnedModel = service.Add(sample);
            Assert.True(addReturnedModel.Id > 0);

            var addFoundModel = service.FindById(addReturnedModel.Id);
            Assert.NotNull(addFoundModel);

            addFoundModel.Sentence = "SAMPLE";
            var updateReturnedModel = service.Update(addFoundModel);

            var updatedFoundModel = service.FindById(updateReturnedModel.Id);
            Assert.Equal(updatedFoundModel.Sentence, addFoundModel.Sentence);

            var deleteSuccess = service.Delete(updatedFoundModel);
            Assert.True(deleteSuccess);

            Assert.Throws<KeyNotFoundException>(() => { service.Delete(updatedFoundModel); });
        }
    }
}
