﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LeapDayTinkering.RaspberryPi.Http
{
    /// <summary>
    /// Eventually this class will be used in a later update to the sample which 
    /// will include functionality for hosting the API behind API Management.
    /// </summary>
    internal class ApimRequestHandler : DelegatingHandler
    {
        private string SubscriberId;

        public ApimRequestHandler(string subscriberId)
        {
            SubscriberId = subscriberId;
        }

        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.Add("Ocp-Apim-Subscription-Key", SubscriberId);
            return base.SendAsync(request, cancellationToken);
        }
    }
}