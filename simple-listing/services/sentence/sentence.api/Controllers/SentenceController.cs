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
    [Route("[controller]")]
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

        [HttpGet]
        public IEnumerable<SentenceEntry> GetListing()
        {
            return _sentenceService.FetchAll();
        }

        [HttpPost]
        public SentenceEntry Add([FromBody] SentenceEntry entry)
        {
            return _sentenceService.Add(entry);
        }

        [HttpPut]
        public SentenceEntry Update([FromBody] SentenceEntry entry)
        {
            return _sentenceService.Update(entry);
        }

        [HttpDelete]
        public bool Delete([FromBody] SentenceEntry entry)
        {
            return _sentenceService.Delete(entry);
        }
    }
}
