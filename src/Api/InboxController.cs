﻿using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Spa.Models;
using Spa.Models.Repositories;

namespace Spa.Api
{
    public class InboxController : ApiController
    {
        private readonly EmailsRepository _emailRepository;

        public InboxController()
        {
            _emailRepository = new EmailsRepository();
        }

        public IEnumerable<Email> GetEmails()
        {
            return _emailRepository.All;
        }

        public HttpResponseMessage PostEmail(Email message)
        {
            _emailRepository.Save(message);
            return Request.CreateResponse(HttpStatusCode.Created, message);
        }
    }
}
