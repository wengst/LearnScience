using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace LS.Core
{
    public static class F
    {
        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="value">需要加密字符串</param>
        /// <returns>返回32位大写字符</returns>
        public static string MD5Encrypt(string value)
        {
            var otherStr = "~12^&09KerLMnttrynlNikeName%#$%";
            //将输入字符串转换成字节数组  ANSI代码页编码
            var buffer = Encoding.Default.GetBytes(value + otherStr);
            //接着，创建Md5对象进行散列计算
            var data = MD5.Create().ComputeHash(buffer);
            //创建一个新的Stringbuilder收集字节
            var sb = new StringBuilder();
            //遍历每个字节的散列数据 
            foreach (var t in data)
            {
                //转换大写十六进制字符串
                sb.Append(t.ToString("X2"));
            }
            //返回十六进制字符串
            return MD5Encrypt(sb.ToString());
        }
    }
}
