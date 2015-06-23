using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using speck.Frameworks.Cryptography;

namespace speck.Frameworks.Test.CryptographyTest
{
    [TestClass]
    public class CryptographyTest
    {
        [TestMethod]
        public void DescryptionTest()
        {
            var strres = CryptionManage.Descryption(CryptionType.DES, "ZlmDmDlvPXrugLVBE8Uz4A==", new byte[] { 1, 2, 3, 3, 2, 1, 6, 5 }, new byte[] { 1, 2, 3, 3, 2, 1, 5, 6 });

        }

        [TestMethod]
        public void EncryptionTest()
        {
            var a = "";
            string strRes = CryptionManage.Encryption(CryptionType.DES, "dengyouhua",
                new byte[] { 1, 2, 3, 3, 2, 1, 6, 5 }, new byte[] { 1, 2, 3, 3, 2, 1, 5, 6 });

        }
    }
}
