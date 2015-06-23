namespace speck.Frameworks.Cryptography
{
    /// <summary>
    /// 对称加密类型
    /// </summary>
    public enum CryptionType
    {
        /// <summary>
        /// des加解密
        /// </summary>
        DES = 1,

        /// <summary>
        /// 3des加解密
        /// </summary>
        TripleDES = 2,

        /// <summary>
        /// aes加解密
        /// </summary>
        AES = 3,

        /// <summary>
        /// rijndael加解密
        /// </summary>
        Rijndael = 4,

        /// <summary>
        /// md5单向加密
        /// </summary>
        Md5 = 5
    }
}
