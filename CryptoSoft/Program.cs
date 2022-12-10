using System.IO;

class Program
{
    static void Main(string[] args)
    {
        var a = args[0];
        var b = args[1];
        using (var fin = new FileStream(a, FileMode.Open))
        using (var fout = new FileStream(b, FileMode.Create))
        {
            byte[] buffer = new byte[4096];
            while (true)
            {
                int bytesRead = fin.Read(buffer);
                if (bytesRead == 0)
                    break;
                EncryptBytes(buffer, bytesRead);
                fout.Write(buffer, 0, bytesRead);
            }
        }
    }
    const byte Secret = 101;

    static void EncryptBytes(byte[] buffer, int count)
    {

        for (int i = 0; i < count; i++)
        {
            buffer[i] = (byte)(buffer[i] ^ Secret);
        }
    }
}