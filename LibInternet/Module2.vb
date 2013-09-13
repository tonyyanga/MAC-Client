Imports System.Security.Cryptography
Imports System.Text
Namespace Crypt
    Friend Module Module2
        Public Function Encrypt(ByVal pToEncrypt As String, ByVal sKey As String) As String
            Dim des As New DESCryptoServiceProvider
            Dim inputByteArray() As Byte
            inputByteArray = Encoding.Default.GetBytes(pToEncrypt)
            ''建立加密对象的密钥和偏移量
            ''原文使用ASCIIEncoding.ASCII方法的GetBytes方法
            ''使得输入密码必须输入英文文本
            des.Key = ASCIIEncoding.ASCII.GetBytes(sKey)
            des.IV = ASCIIEncoding.ASCII.GetBytes(sKey)
            ''写二进制数组到加密流
            ''(把内存流中的内容全部写入)
            Dim ms As New System.IO.MemoryStream
            Dim cs As New CryptoStream(ms, des.CreateEncryptor, CryptoStreamMode.Write)
            ''写二进制数组到加密流
            ''(把内存流中的内容全部写入)
            cs.Write(inputByteArray, 0, inputByteArray.Length)
            cs.FlushFinalBlock()
            ''建立输出字符串    
            Dim ret As New StringBuilder
            Dim b As Byte
            For Each b In ms.ToArray()
                ret.AppendFormat("{0:X2}", b)
            Next
            Return ret.ToString()
        End Function

        Public Function Decrypt(ByVal pToDecrypt As String, ByVal sKey As String) As String
            Dim des As New DESCryptoServiceProvider
            ''把字符串放入byte数组
            Dim len As Integer
            len = pToDecrypt.Length / 2 - 1
            Dim inputByteArray(len) As Byte
            Dim x, i As Integer
            For x = 0 To len
                i = Convert.ToInt32(pToDecrypt.Substring(x * 2, 2), 16)
                inputByteArray(x) = CType(i, Byte)
            Next
            ''建立加密对象的密钥和偏移量，此值重要，不能修改
            des.Key = ASCIIEncoding.ASCII.GetBytes(sKey)
            des.IV = ASCIIEncoding.ASCII.GetBytes(sKey)
            Dim ms As New System.IO.MemoryStream
            Dim cs As New CryptoStream(ms, des.CreateDecryptor, CryptoStreamMode.Write)
            cs.Write(inputByteArray, 0, inputByteArray.Length)
            cs.FlushFinalBlock()
            Return Encoding.Default.GetString(ms.ToArray, 0, inputByteArray.Length)
        End Function

    End Module
End Namespace