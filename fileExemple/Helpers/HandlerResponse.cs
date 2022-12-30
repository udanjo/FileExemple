using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fileExemple.Enums;

namespace fileExemple.Helpers
{
    public class HandlerResponse
    {
        private readonly List<string> _messages = new();

        public ResponseType Type { get; set; }
        public dynamic Data { get; private set; }
        public string Uri { get; private set; }
        public string ContentType { get; private set; }
        public string FileDownloadName { get; private set; }
        public IReadOnlyCollection<string> Messages => _messages.AsReadOnly();


        public static HandlerResponse CreateSuccessResponse()
        => new()
        {
            Type = ResponseType.Success,
            Uri = string.Empty
        };

        public static HandlerResponse CreateFileResponse()
        => new()
        {
            Type = ResponseType.File
        };

        public static HandlerResponse CreateFailResponse(ResponseType type)
        {
            if(!IsStatusFailure(type))
            {
                throw new ArgumentException($"Type {type} is not failure.");
            }

            return new()
            {
                Type = type,
                Uri = string.Empty
            };
        }

        public HandlerResponse WithData(dynamic data)
        {
            Data = data;
            return this;
        }

        public HandlerResponse WithUri(string uri)
        {
            Uri = uri;
            return this;
        }

        public HandlerResponse WithFileData(dynamic data, string contentType, string fileDownloadName)
        {
            Data = data;
            ContentType = contentType;
            FileDownloadName = fileDownloadName;
            return this;
        }

        public HandlerResponse WithMessage(string Message)
        {
            _messages.Add(Message);
            return this;
        }

        public HandlerResponse WithMessages(IEnumerable<string> messages)
        {
            _messages.AddRange(messages);
            return this;
        }

        public void AddMessage(string message) => _messages.Add(message);

        private static bool IsStatusFailure(ResponseType type) => type != ResponseType.Success;
    }
}