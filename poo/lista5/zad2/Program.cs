using System.IO;

namespace zad2
{
    public class CaesarStream : Stream
    {
        private Stream _stream;
        private int _shift;
        
        public CaesarStream(Stream stream, int shift)
        {
            _stream = stream;
            _shift = shift;
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            throw new System.NotImplementedException();
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            throw new System.NotImplementedException();
        }
        
        // **********************************************************************

        public override void Flush()
        {
            throw new System.NotImplementedException();
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            throw new System.NotImplementedException();
        }

        public override void SetLength(long value)
        {
            throw new System.NotImplementedException();
        }

        public override bool CanRead { get; }
        public override bool CanSeek { get; }
        public override bool CanWrite { get; }
        public override long Length { get; }
        public override long Position { get; set; }
    }

    internal class Program
    {
        public static void Main(string[] args)
        {
        }
    }
}