using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace WeddingWebsite.Models.Helpers
{
  public class SixDigitCodeGenerator : ICodeGenerator
  {
    HashAlgorithm _algorithm;

    /// <summary>
    /// DI constructor for Algorithm of choice
    /// </summary>
    /// <param name="algorithm"></param>
    public SixDigitCodeGenerator(HashAlgorithm algorithm)
    {
      _algorithm = algorithm;
    }
    /// <summary> 
    /// Generates 6 digit code.
    /// Stolen from:
    /// http://stackoverflow.com/questions/22208413/c-sharp-random-6-digit-number
    /// </summary>
    /// <returns>6 digit code</returns>
    public string GenerateCode()
    {
      Random generator = new Random();
      String r = generator.Next(0, 1000000).ToString("D6");

      return r;
    }
  
    /// <summary>
    /// Hash generated code
    /// </summary>
    /// <returns></returns>
    public string HashCode(string code)
    {
      if (string.IsNullOrEmpty(code))
        return string.Empty;

      byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(code);
      byte[] hash = _algorithm.ComputeHash(inputBytes);

      // step 2, convert byte array to hex string
      StringBuilder sb = new StringBuilder();
      for (int i = 0; i < hash.Length; i++)
      {
        sb.Append(hash[i].ToString("X2"));
      }
      return sb.ToString();
    }
}
}