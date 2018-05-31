using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace OdnShop.Core.Common
{
    public class HtmlHelper
    {
        private static string html2TextPattern =
                              @"(?<script><script[^>]*?>.*?</script>)|(?<style><style>.*?</style>)|(?<comment><!--.*?-->)" +
                              @"|(?<html><[^>]+>)" + // HTML标记
                              @"|(?<quot>&(quot|#34);)" + // 符号: "
                              @"|(?<amp>&(amp|#38);)" + // 符号: &
                              @"|(?<lt>&(lt|#60);)" + // 符号: <
                              @"|(?<gt>&(gt|#62);)" + // 符号: >
                              @"|(?<iexcl>&(iexcl|#161);)" + // 符号: (char)161
                              @"|(?<cent>&(cent|#162);)" + // 符号: (char)162
                              @"|(?<pound>&(pound|#163);)" + // 符号: (char)163
                              @"|(?<copy>&(copy|#169);)" + // 符号: (char)169
                              @"|(?<others>&(\d+);)" + // 符号: 其他
                              @"|(?<space>&nbsp;|&#160;)"; // 空格

        /// <summary>
        /// 获得html的body部分
        /// </summary>
        public static string GetBodyContentFromHtml(string html)
        {
            Regex re = new Regex(@"[\s\S]*?<\bbody\b[^>]*>", RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace);
            html = re.Replace(html, "");

            re = new Regex(@"</\bbody\b[^>]*>\s*</html>", RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace | RegexOptions.RightToLeft);
            html = re.Replace(html, "");

            return html;
        }

        /// <summary>
        /// 转换HTML为纯文本
        /// </summary>
        /// <param name="html">HTML字符串</param>
        /// <param name="keepFormat">是否保留换行格式</param>
        /// <returns></returns>
        public static string Html2Text(string html, bool keepFormat)
        {
            string pattern = html2TextPattern;
            if (!keepFormat) pattern += "|(?<control>[\r\n\\s])"; // 换行字符

            RegexOptions options = RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.Compiled;
            string txt = Regex.Replace(html, pattern, new MatchEvaluator(Html2Text_Match), options);

            if (!keepFormat)
                return Regex.Replace(txt.Trim(), "[\u0020]+", "\u0020", options); // 替换多个连续空格
            else
                return txt;
        }

        private static string Html2Text_Match(Match m)
        {
            if (m.Groups["quot"].Value != string.Empty)
                return "\"";
            else if (m.Groups["amp"].Value != string.Empty)
                return "&";
            else if (m.Groups["lt"].Value != string.Empty)
                return "<";
            else if (m.Groups["gt"].Value != string.Empty)
                return ">";
            else if (m.Groups["iexcl"].Value != string.Empty)
                return "\xa1";
            else if (m.Groups["cent"].Value != string.Empty)
                return "\xa2";
            else if (m.Groups["pound"].Value != string.Empty)
                return "\xa3";
            else if (m.Groups["copy"].Value != string.Empty)
                return "(c)";
            else if (m.Groups["space"].Value != string.Empty)
                return "\u0020";
            else if (m.Groups["control"].Value != string.Empty)
                return "\u0020";
            else
                return string.Empty;
        }
    }
}
