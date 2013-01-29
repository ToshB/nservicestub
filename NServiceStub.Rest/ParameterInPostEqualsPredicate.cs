﻿using System;
using System.Net;

namespace NServiceStub.Rest
{
    public class ParameterInPostEqualsPredicate<T> : IInvocationMatcher
    {
        private readonly IPostTemplate _routeOwningUrl;
        private readonly Func<T, bool> _predicate;
        private readonly ParameterLocation _parameterLocation;
        private readonly string _parameterName;

        public ParameterInPostEqualsPredicate(IPostTemplate routeOwningUrl, Func<T, bool> predicate, ParameterLocation parameterLocation, string parameterName)
        {
            _routeOwningUrl = routeOwningUrl;
            _predicate = predicate;
            _parameterLocation = parameterLocation;
            _parameterName = parameterName;
        }

        public bool Matches(HttpListenerRequest request)
        {
            var parameterValue = _routeOwningUrl.Route.GetParameterValue<T>(request, _parameterName, _parameterLocation);

            return _predicate(parameterValue);
        }
    }
}