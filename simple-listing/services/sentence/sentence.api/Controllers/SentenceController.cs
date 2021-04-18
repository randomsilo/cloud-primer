using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using sentence.domain.model;
using sentence.domain.service;
using sentence.domain.impl;

namespace sentence.api.Controllers
{
    [ApiController]
    public class SentenceController : ControllerBase
    {
        private readonly ILogger<SentenceController> _logger;
        private readonly ISentenceService _sentenceService;

        public SentenceController(ILogger<SentenceController> logger, ISentenceService sentenceService)
        {
            _logger = logger;
            _sentenceService = sentenceService;
        }

        // HTTP Verb Reasoning
        // https://www.restapitutorial.com/lessons/httpmethods.html#:~:text=The%20primary%20or%20most%2Dcommonly,or%20CRUD)%20operations%2C%20respectively.

        [Route("api/sentence/fetchall")]
        [HttpGet]
        public IEnumerable<SentenceEntry> FetchAll()
        {
            return _sentenceService.FetchAll();
        }

        [Route("api/sentence/findbyid/{id}")]
        [HttpGet]
        public SentenceEntry FindById(long? id)
        {
            return _sentenceService.FindById(id);
        }

        [Route("api/sentence/add")]
        [HttpPost]
        public SentenceEntry Add([FromBody] SentenceEntry entry)
        {
            return _sentenceService.Add(entry);
        }

        [Route("api/sentence/update")]
        [HttpPut]
        public SentenceEntry Update([FromBody] SentenceEntry entry)
        {
            return _sentenceService.Update(entry);
        }

        [Route("api/sentence/delete")]
        [HttpDelete]
        public bool Delete([FromBody] SentenceEntry entry)
        {
            return _sentenceService.Delete(entry);
        }

        [Route("api/sentence/deletebyid/{id}")]
        [HttpDelete]
        public bool Delete(long? id)
        {
            var entry = new SentenceEntry() 
            {
                Id = id
            };
            return _sentenceService.Delete(entry);
        }
    }
}
