using System;
using System.Collections.Generic;
using Lykke.Job.SMS.Core.Domain.Health;
using Lykke.Job.SMS.Core.Services;

namespace Lykke.Job.SMS.Services
{
    // NOTE: See https://lykkex.atlassian.net/wiki/spaces/LKEWALLET/pages/35755585/Add+your+app+to+Monitoring
    public class HealthService : IHealthService
    {
        // NOTE: These are example properties
        private DateTime LastFooStartedMoment { get; set; }
        private TimeSpan LastFooDuration { get; set; }
        private TimeSpan MaxHealthyFooDuration { get; }
        private bool WasLastFooFailed { get; set; }
        private bool WasLastFooCompleted { get; set; }
        private bool WasClientsFooEverStarted { get; set; }

        // NOTE: When you change parameters, don't forget to look in to JobModule

        public HealthService(TimeSpan maxHealthyFooDuration)
        {
            MaxHealthyFooDuration = maxHealthyFooDuration;
        }

        // NOTE: This method could stay in the real job, but will be modified
        public string GetHealthViolationMessage()
        {
            // TODO: Check gathered health statistics, and return appropriate health violation message, or NULL if job hasn't critical errors
            return null;
        }

        public IEnumerable<HealthIssue> GetHealthIssues()
        {
            var issues = new HealthIssuesCollection();

            if (WasLastFooFailed)
            {
                issues.Add("SMSFooProcessing", "Last foo was failed");
            }

            if (!WasLastFooCompleted && !WasLastFooFailed && !WasClientsFooEverStarted)
            {
                issues.Add("SMSFooProcessingNotStartedYet", "Waiting for first foo execution started");
            }

            if (!WasLastFooCompleted && !WasLastFooFailed && WasClientsFooEverStarted)
            {
                issues.Add("SMSFooProcessingNotCompletedYet", $"Waiting {DateTime.UtcNow - LastFooStartedMoment} for first foo execution completed");
            }

            if (LastFooDuration > MaxHealthyFooDuration)
            {
                issues.Add("SMSFooProcessingLastedForToLong", $"Last foo was lasted for {LastFooDuration}, which is too long");
            }

            return issues;
        }

        // NOTE: These are example methods
        public void TraceFooStarted()
        {
            LastFooStartedMoment = DateTime.UtcNow;
            WasClientsFooEverStarted = true;
        }

        public void TraceFooCompleted()
        {
            LastFooDuration = DateTime.UtcNow - LastFooStartedMoment;
            WasLastFooCompleted = true;
            WasLastFooFailed = false;
        }

        public void TraceFooFailed()
        {
            WasLastFooCompleted = false;
            WasLastFooFailed = true;
        }
    }
}