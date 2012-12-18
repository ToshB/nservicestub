﻿namespace NServiceStub.Rest
{
    public class LogicalOrOfInvocations : IInvocationMatcher
    {
        private readonly IInvocationMatcher _left;
        private readonly IInvocationMatcher _right;

        public LogicalOrOfInvocations(IInvocationMatcher left, IInvocationMatcher right)
        {
            _left = left;
            _right = right;
        }

        public bool Matches(string rawUrl, IRouteDefinition routeOwningUrl)
        {
            return _left.Matches(rawUrl, routeOwningUrl) || _right.Matches(rawUrl, routeOwningUrl);
        }
    }
}