﻿using Amazon.AppConfigData;
using Microsoft.Extensions.Configuration;

namespace Extensions.AwsFeatureFlags
{
    public class AmazonFeatureFlagConfigSource : IConfigurationSource
    {
        private readonly AmazonAppConfigDataClient _client;
        private readonly AmazonAppConfigSettings _cfg;

        public AmazonFeatureFlagConfigSource(AmazonAppConfigDataClient client, AmazonAppConfigSettings cfg)
        {
            _client = client;
            _cfg = cfg;
        }
        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            return new AmazonFeatureFlagProvider(_client, _cfg);
        }
    }
}