using System.Text;

namespace Optimus.AtHomeBestOffer.Application.Helper
{
    public class Utf8StringWriter : StringWriter
    {
        public override Encoding Encoding => Encoding.UTF8;
    }
}