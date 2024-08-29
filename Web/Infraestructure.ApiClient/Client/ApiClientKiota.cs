// <auto-generated/>
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Serialization.Form;
using Microsoft.Kiota.Serialization.Json;
using Microsoft.Kiota.Serialization.Multipart;
using Microsoft.Kiota.Serialization.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System;
using UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.ActiveUsers;
using UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Weatherforecast;
namespace UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient {
    /// <summary>
    /// The main entry point of the SDK, exposes the configuration and the fluent API.
    /// </summary>
    public class ApiClientKiota : BaseRequestBuilder 
    {
        /// <summary>The activeUsers property</summary>
        public ActiveUsersRequestBuilder ActiveUsers
        {
            get => new ActiveUsersRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The weatherforecast property</summary>
        public WeatherforecastRequestBuilder Weatherforecast
        {
            get => new WeatherforecastRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>
        /// Instantiates a new <see cref="ApiClientKiota"/> and sets the default values.
        /// </summary>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public ApiClientKiota(IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}", new Dictionary<string, object>())
        {
            ApiClientBuilder.RegisterDefaultSerializer<JsonSerializationWriterFactory>();
            ApiClientBuilder.RegisterDefaultSerializer<TextSerializationWriterFactory>();
            ApiClientBuilder.RegisterDefaultSerializer<FormSerializationWriterFactory>();
            ApiClientBuilder.RegisterDefaultSerializer<MultipartSerializationWriterFactory>();
            ApiClientBuilder.RegisterDefaultDeserializer<JsonParseNodeFactory>();
            ApiClientBuilder.RegisterDefaultDeserializer<TextParseNodeFactory>();
            ApiClientBuilder.RegisterDefaultDeserializer<FormParseNodeFactory>();
        }
    }
}