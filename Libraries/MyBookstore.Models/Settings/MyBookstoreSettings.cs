using System;
using System.Collections.Generic;
using System.Text;

namespace MyBookstore.Models
{
    public class MyBookstoreSettings
    {
        public string OrderServiceEndpointAddress { get; set; }
        public string AttachmentsFolder { get; set; }
        public long AttachmentMaxFileSize { get; set; }
        public string ConnectionString { get; set; }
    }
}
