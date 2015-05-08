﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace testClient
{
    class Program
    {
        static public void test()
        {
            byte[] bin = new byte[65535];
            string[] del = new string[1];
            del[0] = "||";

            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress serverIP = IPAddress.Parse("127.0.0.1");
            IPEndPoint server = new IPEndPoint(serverIP, 1277);
            s.Connect(server);

            string fin = "lz77||" + "3c3f786d6c2076657273696f6e3d22312e302220656e636f64696e673d2253484946545f4a4953223f3e3c726573706f6e73653e3c49494458323170633e3c70636461746120645f646973705f6a756467653d22302220645f676e6f3d22302220645f67747970653d22302220645f686973706565643d22302e3030303030302220645f6a756467653d22302220645f6a7564676541646a3d22302220645f6c69666c656e3d22302220645f6e6f7465733d22302e3030303030302220645f6f707374796c653d22302220645f706163653d22302220645f73646c656e3d22302220645f7364747970653d22302220645f736f7274747970653d22302220645f74696d696e673d22302220646163683d2230222064705f6f70743d2230222064705f6f7074323d2230222064706e756d3d2230222067706f733d2231222069643d223732383932343934222069647374723d224655434b2d594f552122206d6f64653d223022206e616d653d22444a2e4655434b45525322207069643d2235332220706d6f64653d2230222072747970653d22302220735f646973705f6a756467653d22312220735f676e6f3d22322220735f67747970653d22312220735f686973706565643d22322e3133363034352220735f6a756467653d22302220735f6a7564676541646a3d22302220735f6c69666c656e3d2236302220735f6e6f7465733d2233322e3931303438382220735f6f707374796c653d22312220735f706163653d22302220735f73646c656e3d223133332220735f7364747970653d22312220735f736f7274747970653d22302220735f74696d696e673d22312220736163683d2238303834222073705f6f70743d2238313934222073706e756d3d22323231223e3c2f7063646174613e3c7365637265743e3c666c6731205f5f747970653d2273363422205f5f636f756e743d2232223e38323134353635323331373639333931313033203837393630393330323232343839363c2f666c67313e3c666c6732205f5f747970653d2273363422205f5f636f756e743d2232223e393232333337313936393139323236343133352035363c2f666c67323e3c666c6733205f5f747970653d2273363422205f5f636f756e743d2232223e3835383939333435393120303c2f666c67333e3c2f7365637265743e3c616368696576656d656e7473206c6173745f7765656b6c793d223022207061636b3d223022207061636b5f636f6d703d223022207061636b5f69643d22302220726976616c5f63727573683d2230222076697369745f666c673d223131323538393939303638343236323422207765656b6c795f6e756d3d2230223e3c74726f706879205f5f747970653d2273363422205f5f636f756e743d223130223e2d35313838313436383432393733343939333935203135313433333636343131303239313037313820393037303937353430333839332033353138333833353231373932302030203137333833383937333130343331383035343920302030203020303c2f74726f7068793e3c2f616368696576656d656e74733e3c737465702064616d6167653d223822206465666561743d2235222064705f6c6576656c3d2230222064705f6d697373696f6e3d2230222064705f6d706c61793d223022206c6173745f73656c6563743d2232222070726f67726573733d22352220726f756e643d2231222073705f6c6576656c3d22313033222073705f6d697373696f6e3d2230222073705f6d706c61793d223132223e3c616c62756d205f5f747970653d2262696e22205f5f73697a653d223132223e3030303030303030303030303030303030303030303030303c2f616c62756d3e3c2f737465703e3c626f7373312061747461636b3d22322220626174746c653d22302220626f7373305f613d22302220626f7373305f64616d6167653d22302220626f7373305f683d22302220626f7373305f6e3d22302220626f7373315f613d22302220626f7373315f64616d6167653d22302220626f7373315f683d22302220626f7373315f6e3d22302220626f7373325f613d22302220626f7373325f64616d6167653d22302220626f7373325f683d22302220626f7373325f6e3d22302220626f7373335f64616d6167653d22302220626f7373345f64616d6167653d22302220626f7373355f64616d6167653d22302220626f7373365f64616d6167653d22302220626f73735f7363656e653d22302220636f6c756d6e303d2231312220636f6c756d6e313d22302220636f6c756d6e323d22302220636f6c756d6e333d2230222067656e6572616c3d22363635363022206974656d313d223022206974656d323d223022206974656d333d223022206974656d5f666c673d223232303036343232353731353822206974656d5f666c67323d223022206a6f623d223122206d61703d223422207069636b3d22302220726f77303d2231382220726f77313d22302220726f77323d22302220726f77333d223022207374616d696e613d2230223e3c6c6576656c205f5f747970653d2273333222205f5f636f756e743d2237223e312031203120312031203120313c2f6c6576656c3e3c6475726162696c697479205f5f747970653d2262696e22205f5f73697a653d22363430223e30303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303c2f6475726162696c6974793e3c2f626f7373313e3c626f7373315f706861736534206d61705f636c6561725f666c673d2230223e3c6e65775f6475726162696c697479205f5f747970653d2262696e22205f5f73697a653d22363430223e30653030303030303030303030303030303030353030303630303030303030303030303030613030303530613134303033633165306135353134303030663332303030303066313431343030306530633061303230653030303030613061303030303030303130303030303030613061303030303030303030303030303130303031303030613061306530303165306630663030303031343030303030303037303731393139306630663030306531653139303030303030303030303134303030663066303033633363306630303066306630303462303030303132303031323132303030303031303030303030313230303030303030313030313230303030303030303131303030313030303030303031303030303031303130303134303130303134313831343134323830303238303033633030313430303030323830303030303030303030303030303031313431343031313430613030303030303030303031343134303130303134313430313264316530303030353532383031303032643165303030303030303030303030303030303030303031653134313430613030303030613061313430303134303030303030303030613061303030303238316530303030316530303030303032383238353531653030303030303030316530303030323832383238316530303139313931393139303930393139306131343030303030303030303030303030303030303030303030663031303030303030303030303030303030303030303633323165303130303162316431653165316230663165316530663066303130303030303030303030303030303030303030303030303130303031303030313030303030303030303030303030303130303030303030303030303030303030303030613061316531653030303031653165316531343332303030303030353032643238303030303030303030303030303030303238323832383030303030303030303032383031303030303030303030303030303030313031303130313031303030313031303030303030303130303165303030303165303031653030323830303030303031653030303030613030303033323332333230303233303031653030303133323031333233633332323333323031333230313332323333323031333230313030313430303332333233323031333230313332333233323031333230313332333233323030303033323030303030303030303033633030303030303031303133633633363331343134363336333633333232643633363336333535303030303030303130303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303c2f6e65775f6475726162696c6974793e3c2f626f7373315f7068617365343e3c6661766f726974653e3c73705f6d6c697374205f5f747970653d2262696e22205f5f73697a653d223830223e303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303c2f73705f6d6c6973743e3c73705f636c697374205f5f747970653d2262696e22205f5f73697a653d223230223e303030303030303030303030303030303030303030303030303030303030303030303030303030303c2f73705f636c6973743e3c64705f6d6c697374205f5f747970653d2262696e22205f5f73697a653d223830223e303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303030303c2f64705f6d6c6973743e3c64705f636c697374205f5f747970653d2262696e22205f5f73697a653d223230223e303030303030303030303030303030303030303030303030303030303030303030303030303030303c2f64705f636c6973743e3c2f6661766f726974653e3c6c696e6b3520616e6973616b69733d223122206261643d223122206265616368736964653d2231222062656175746966756c3d2231222062726f6b656e3d22312220636173746c653d223122206368696e613d22312220637576656c69613d223122206578757369613d2231222066616c6c656e3d22312220666c69703d22312220676c6173733d22312220676c617373666c673d223122207170726f3d223122207170726f666c673d223122207175617665723d223122207265666c65635f646174613d223122207265756e696f6e3d2231222073616b7572613d2231222073616d706c696e673d223122207365636f6e643d2231222073756d6d65723d22312220737572766976616c3d223122207468756e6465723d22312220746974616e733d2231222074726561737572653d2231222074757269693d22312220776178696e673d22312220776879646964796f753d223122207775763d2231223e3c2f6c696e6b353e3c6361666520617374726169613d223122206261737469653d223122206265616368696d703d22312220666f6f643d22302220686f6c79736e6f773d2231222069735f66697273743d223022206c656476737363753d223122207061737472793d223022207261696e626f773d22312220736572766963653d2230222074727565626c75653d2231223e3c2f636166653e3c67616b75656e206d757369635f6c6973743d2231303233223e3c2f67616b75656e3e3c6261736562616c6c206d757369635f6c6973743d222d31223e3c2f6261736562616c6c3e3c747269636f6c657474657061726b2061747461636b5f726174653d22302220626f7373305f64616d6167653d22302220626f7373305f7374756e3d22302220626f7373315f64616d6167653d22302220626f7373315f7374756e3d22302220626f7373325f64616d6167653d22302220626f7373325f7374756e3d22302220626f7373335f64616d6167653d22302220626f7373335f7374756e3d2230222069735f756e696f6e3d223022206d616769635f67617567653d223022206f70656e5f6d757369633d222d31222070617274793d2230223e3c2f747269636f6c657474657061726b3e3c707972616d6964206974656d5f6c6973743d222d3122206d757369635f6c6973743d222d3122207374617475655f303d223222207374617475655f313d223222207374617475655f323d2232223e3c2f707972616d69643e3c677261646520646769643d222d312220736769643d223132223e3c67205f5f747970653d22753822205f5f636f756e743d2234223e30203720342035323c2f673e3c67205f5f747970653d22753822205f5f636f756e743d2234223e3020313220342038303c2f673e3c2f67726164653e3c6a6f696e5f73686f70206a6f696e5f63666c673d223122206a6f696e5f69643d2255532d3131393322206a6f696e5f6e616d653d22e2809a6de2809ac28fe2809a6de2809ac281e2809ac28de2809ae280a622206a6f696e666c673d2231223e3c2f6a6f696e5f73686f703e3c7170726f64617461205f5f747970653d2275333222205f5f636f756e743d2235223e3020302030203020303c2f7170726f646174613e3c736b696e205f5f747970653d2273313622205f5f636f756e743d223134223e30203133203134203120313520343220302031203620313120372038202d3120303c2f736b696e3e3c726c6973743e3c726976616c2064613d2230222064673d222d312220646a6e616d653d22424a222069643d223333303136343239222069645f7374723d22333330312d3634323922207069643d223533222073613d2239303135222073673d2231322220737064703d2231223e3c737465706461746120737465705f646163683d22302220737465705f736163683d22313732223e3c2f73746570646174613e3c7170726f6461746120626f64793d2236372220666163653d2231342220686169723d2234222068616e643d2239392220686561643d2230223e3c2f7170726f646174613e3c73686f70206e616d653d22e2809a4fe2809a4fe2809a4fe2809a4fe2809a4fe2809a4fe2809a4fe2809a4fe2809a4fe2809a4fe2809a4fe2809a4f223e3c2f73686f703e3c2f726976616c3e3c726976616c2064613d2230222064673d222d312220646a6e616d653d22424a222069643d223333303136343239222069645f7374723d22333330312d3634323922207069643d223533222073613d2239303135222073673d2231322220737064703d2232223e3c737465706461746120737465705f646163683d22302220737465705f736163683d22313732223e3c2f73746570646174613e3c7170726f6461746120626f64793d2236372220666163653d2231342220686169723d2234222068616e643d2239392220686561643d2230223e3c2f7170726f646174613e3c73686f70206e616d653d22e2809a4fe2809a4fe2809a4fe2809a4fe2809a4fe2809a4fe2809a4fe2809a4fe2809a4fe2809a4fe2809a4fe2809a4f223e3c2f73686f703e3c2f726976616c3e3c726976616c2064613d2230222064673d222d312220646a6e616d653d224646464646222069643d223433393533363237222069645f7374723d22343339352d3336323722207069643d2234222073613d223135393436222073673d2231332220737064703d2231223e3c737465706461746120737465705f646163683d22302220737465705f736163683d22313533223e3c2f73746570646174613e3c7170726f6461746120626f64793d22372220666163653d2232392220686169723d22313130222068616e643d223132382220686561643d223931223e3c2f7170726f646174613e3c73686f70206e616d653d22e2809d5ae28093c2a7e2809870e28094c391e28098c3a5c290c3ad223e3c2f73686f703e3c2f726976616c3e3c726976616c2064613d2230222064673d222d312220646a6e616d653d224841525259222069643d223438373433323836222069645f7374723d22343837342d3332383622207069643d223438222073613d2239353733222073673d2231332220737064703d2231223e3c737465706461746120737465705f646163683d22302220737465705f736163683d22313437223e3c2f73746570646174613e3c7170726f6461746120626f64793d22362220666163653d22362220686169723d22313134222068616e643d22362220686561643d22313032223e3c2f7170726f646174613e3c73686f70206e616d653d22c69243c69255c2815bc6924ee280b0c2a4c28de28098223e3c2f73686f703e3c2f726976616c3e3c2f726c6973743e3c64656c6c65722064656c6c65723d2239393939393939392220726174653d2230223e3c2f64656c6c65723e3c2f49494458323170633e3c2f726573706f6e73653e" + "||ENC||";

            s.Send(Encoding.Default.GetBytes(fin));
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               
            byte[] bbb = new byte[90000];

            while (true)
            {
                int recved = s.Receive(bbb);
                int b = recved;

            }
        }
        static public void test2()
        {
            byte[] bin = new byte[65535];
            string[] del = new string[1];
            del[0] = "||";

            string key = "1-5541d718-da42";

            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress serverIP = IPAddress.Parse("127.0.0.1");
            IPEndPoint server = new IPEndPoint(serverIP, 1264);
            s.Connect(server);

            string fin = key + "||" + "3c3f786d6c2076657273696f6e3d22312e302220656e636f64696e673d2253484946545f4a4953223f3e3c726573706f6e73653e3c6d657373616765207374617475733d2230223e3c2f6d6573736167653e3c2f726573706f6e73653e" + "||ENC||";

            int len = fin.Length;

            int sent = s.Send(Encoding.Default.GetBytes(fin));
        }
        static public void test3()
        {
            byte[] bin = new byte[65535];
            string[] del = new string[1];
            del[0] = "||";

            string key = "1-54e9fc5c-1a7b";

            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress serverIP = IPAddress.Parse("127.0.0.1");
            IPEndPoint server = new IPEndPoint(serverIP, 12764);
            s.Connect(server);

            string fin = key + "||" + "9382A5B93A51A809EFBCD11AEDADC754C7EC5CA111E8D8147A13D909941E0FBB8EEBD472822B01F23EA48E0D3D2D6514EA4EBB11EFE67BC2D816CBD0126D56C0E857373A04BC6557C6A2B6B06E56BD510CDFA89CF2EE81640877AC6DDF1F1BFB54629D7A287783C43711E6B6D7C51D6AC53EAE13D7C35DC07803AE37CFDE946071BD97726973D7E118767E452F5AC7CB5AA8D835E2954FF44136B2A064319E9E91AEA6892675D361AB34FB910F4EB6BBCF0BCAA35B8940C92295BBB94C6F4653137227F29D862C6625C4E84E546B10F29E885E57F1E1314F32E00C71C550520ABE6B67B4D19D80E6D39C62D0CD8869BDCCE87A1FBC8BA09F7741D58CDE888EF54CCC6EE0B86D387482E70A5EE1751B00D64BFA0550DAB702417C72EF4A9B2DCC05E4270EA31BC52F85D28A3A40B0EF257670CACA3C16FC97AE79BA3F26090BD387AD916A350E276AD6EF0B3DE0422672A89B5BA973C3D6476687B1FEC61B70F7497CB7DEBEF65507F2D2DA8009972C7D471FE8A12E053C2F1417849532F72A96BC2F5FB1DC57D8D4FBC6971E46F51BE6C0A60F3F386A3EE687BF78FD12706215EE234FD446FB0B87163536947A2B5641DD9CEC512F1FC25B2578F3C0A7754AC4FC51930407B78134014BE44671FF8071B3D1F16E7E2959F1DECA1DA807811110246D76288CD89AEA010C6953A34AADAE6F6D8971FB0959B4EE512D3429FE1B8F25E7FE41451A545B402F74C1DBD61B59B3EDA0FC999228467E9CE75B73F11A2BC44D205269918F55D9345D9529F07387ADCF0193389EEC713E2AA655C6172D661F25CD196B6D4B41C87FAD17683A1A4CFA546D82D7F07824738C89E9B28D4919F7910A855C8F4776AB4AD6B3AA555BDCC90C5E9D90AA6F2F08CDBAC3D4CEB2E4E8E7E1DE986ACA74364BE1B73E75F22979DFE9BA10B5D71F05CDA385E2FBE0CAD06B915286D11490D2E4D733D55E0475DC0EAFC32E92EEBF6BCDCCB7E09A9491481CFCB7CF1D777923F40729AC62304214671B4ADD5EAB32A60A694DFC4E80B4A15441698FFC1AC4B4C6FF26549736855A316A91C33B90EFB300BACB6A545841D9A008C5D838318ED7C9AE3C24F194EB2B31658441B0E3CA48307A572B4E4B3A9ACECF89FC81E05B388A1DC7C0DD645D2B94AAC773B3A7B1F66D3C62C1EB0AFC3B6F3FC633D0CBB6877464FBF1C118B487C7FE88C708A1CCB5B4DB6ACADE2D8C5126A1B9CAF24879837752484BE65FB63B7F4D4A210D3A04FBE6E5102B62C4A73A766BC0A1EDF532F625565B76A93735D1E2498F894CA531B4E4234CC6E17C78EC49E35F7178D46A1ED3AA410235E8FBDE86D6D834B9DD9392505E8297F8686750252CFECAA2B0D47742CA99FD692A05B7632758F19BC028D4CB4CC49F4660C8BCFF845D4604001BCC9532F644D8840205E21F3E242A36BBB84915741E64139658129003A5525C71E4DB0E39002A7C22ED582410B794D89A2BB6842340B74751808773F0F00BA5F78250924CEAF217F8B1F2955E18E655B72338F4B7EC4B4123EBFE25C933A3562A90B4433808B85B7B2784DEF3050BC5A34B217C93AE059E78066DFE49B8019EFAA15CDD3821C3382DC0FBE296CA37BCF8367FF5F47E8DCC22D320E943A0732208DBAAD6A56083BBF43B6DA3F314464E0C6D4B4762D4FF127EEA872E3129F06516CC70663116859795E7949956DC1A7B2B558C8510AF148C6A7CF08E7405B3090C532FE515F569A7E026EEC5D1B8AEAD6899FA891F3C3B23E46B0D20640E9E2C039675422433A96CDE6944E3D3E81BAE15189E5BA6164A5B80FF48E06106F7E89FFC1A3A124FC60F835934F65D4D6C0BE610D073238DBFB3D9FD7F3E785878E2FEF094F68675241B32A9F0D8631CDA0174636D59DF8A63818A86B5AE46E5BD9EE2036771A1B65345B1FA4E610CADA33E002E063DED3FBCDF30930709D8836905471CBEFFBED27E77852172F018EA6B8AE77B9964EC69D8032C0BA76658379CEA801CAB85513D12339669E0503BDD148A7BABEDA35B6DE662068336A1032011708DD88A4DB3FC31F2B7B631ED22D012CA67BD90F3BE21161A8639B3CA13DAE8210599C3B3F09334A836232A1FEF9E6C92E63ED372788CDA6FA14AF57DFAB5BB0B761460F4317BA9473764288A9B4239AF218BEC22BCB26602B415A1A9E3B4DFF2BC89A4094A8E5703A88392850AFD10EB7BB4A27C18ED6350671496F5F86A09B58F6BBEBA787CCE421B59CC9BB1F8423CA2F264676E2AF5A5635813898DADECFF8887301D09B797B06FCD2FA801B0E1E26CE79B7518BF2D0A90A97EED4695CD5D38707183B0C05398605D99B3A50B5E27E061E769C831A4B5C9604747D4A4E3DC91F240D3A286DA389E4E7AF0550085B3A5FFFF2A096607D6A385DE0314E9A00A556778E7CA4BE4A2BB43EA01FD78DAA8E7EA7937D3CF3BED9C3A4E548A57B21F1B8AB52885D76589CA6DA27523E9C083607941A777A6F002D2323785D68C51C2A344BD6DF3C6DFCD5A3D0F703EF51011E4042997B172F5BC951AE8975BB1004094C8D3F8C9158C434B588E2DC4FF0D4B269F9296F4B14521AD025F51EDE7DA903319954D243175358C00A4064DA2B26F915EA55B463DEC4464E1C005599FE5AED4B293F91B1D66AC7F75FE511035B048A601097962A5569783A50BEBB75997649473747BBD11E71A3AE0FC9CF926969A1CF19CD2C7B4128B2E40728F51125CCE8F42254DF83A36DA66824144E32F7FB23CCF708BB3477376899CEA2DEFF9AF1D319162A02A8D1E340D6A441BA5ECC868920F71CF50783108A0E63990FEFCBFED06EDD408C559443A7C5EA7045F90A3242C262C0D44C58BFE2C71C975EF11B2B872EAFEC0A6D12F7D4347853F4249396A0D1DF942A99AA65133C9A5E7BFDFBF9B84B0ABD21D031FA1A3DE495A6794A38F455BED9A4686253FF5B7255ABE8B8838B6A89BF2A27FC5292BE684912CB7200E5CDC844D0B0E6DFD2E63A7931D7FEBCF31827932C0CA4A702F52FBEE6F7696AEBB2B7BCEFAE43776249C4E5C579A994D475312F7AF853177052E5DCAE8A89E78F20A5898C98F2D7EBD0896BB622C506F71AE7316D87EBD29BA6D47BB645477805E7C6E1DAFCFB44D51AAE95EC54122C8BDE628E90B13DB1675272B5F93A9008A09B6E862A051F6282CE7D7E6912534C57B9563D395B0DDCF628D74E9C3E29D5C86866C5CBF3D788ACB18619218FB8CC4D330C950CBB348C8DEFB82F62CFD5AEBE22752AC9BD49AC276A2CC5630EB7E35244AB1AB55ECEC8CBC1891417FEE44F90958569910C3399C8F9F0FA14C86AC45173EE36794BC856D0AEAB176F3E87CDC8CFE8A43943D6D05AF63090737D183AEAE1D3C15DFC6A03CD201FC45F1AE677FAFA225EA264560F1BBE95D93B6308BD213C299F75022D74A740537EF04BD4B0C2436172772EF97E191FDFDCF43AEFB296CCD2E23F164B04DB9292C64F6BC547CD378F7F49829EE2B582A660E3F0A1532FCDEA6E5123CDAA2ED12AC51DDCE55D70B56DFA6CD6AAF3BE6741428230D62BA00BF644E918B0750D92D5C7E18D4F45E442CFA1F1C02420D400FCC37BAAEF6BDA5C53D1290C6D4D2419C19679C3E229F36710C8C474A67A37D13A73243C8029E88E2A99DE9B4253BCBBF080CDBA82456FEF4DBDA17AAE3F4A20EE79A2C5C011F7E1DE38A5373586EAA6CCE6CDCD42CA271116B820B723B4AE2F23DADCB096B9D92B7CF5DE6B567C1961ED5054E9E42EA305A408C2EF8748E96E849A9656C4ACD0EAE72F041D4EA683297FA6451565693E77A8CCB2254846103E9FA3EA324014CD4A912E2C601639EB66E50AAD06C1FE38864DB2925D7214D2793A13AEF03FC50EBE90CC3EC1823E8D70F059ECC80F12C99AFF6A5DC12C7401C210B1FE8B861F652611C892B87B95368A7341F99693C0F1844DDA72D73DFAD96E24509BDCA98A298D66BEBC30781D2FCBD9E49BC08D7C81A358ADAFD17B30FC3AB657FFAAED577F1159A497D3BB84173E2797361B24E7456A37EC753AC58F285B48188F5825462A2074CF449633FE7F078A4061D5DDF313D9867843FE7442444F4931EBFCAA3F57D18AF88A04D9F1BE3AFFF27D3DD0B507DEB323773B7F8C2E7D4A745F1E6B421357B4FB95CB99338E79B0DB363F531772D802E0C367B3B72291ED48BF779E2599887FDBB63A4711DFD661CAAFED7D0862184ED7D07B9DCA1A02F095CCE45DBD6E5E320A44B7A6D479A5FD1E2CA54D3B4D86A517653FDC6C198E855B3BCAB779A5F036BF7FBA250A1A7EE0EBFE2BEBDC4E02D1533824EDA096D2F2AC1420D6F011CCF9458F7EF04C69C1A759CA854F8BCC5A20499C09A3A6FEBC900F770EED313725F6496224F513D3C889F683869DC5BE61E6005306781DDDA488F447201345F465BD1D20D0C4D8B1203E2E1543C96F50241776454B8FC7C5CC72CAC4C2B4BCE2C534AF2C0D81A2FE6B11D822D107AFEDB3F58D53D53CB3177037CF5FC65277EA1FC30EF1348A57ACBC68F11E12DB99DB914B6658E74C8B58340CAF6D8E584C67E462D4B62C19CC8FE25408015ED9057BACB60DAD56417D28E63A615E242780A655277D7C00C5977F3B0C0ADFDE8B3BADF9A02E15BC9183FC1F9FADEEE191F4A6CC00A6CF8F53A69CDF0E6E490EC337301E700ABFD0B5EDAD867C111FCCBAD96160AB0E222C7FEAA397C1EAC856A915D73C955C1CF873D4328CB746D705CEB7334F6D2F3A1B0C8A3C8435E9F874B240D495C60B079C0D566DABFDDCCEB6893B1DA0CA24A557CE233A816F66149F1A2E8A64680CD105256504E64D85D65AD6DD4E91AC12880AEFE99A8B18469AE6213E534AA1A83FCA90C4180D994D1CFAACF34B7E8CA1CAD266118E7574D6F1E812C5F4D5FDAC20B94C13639D477AF8EB69052FEB3C04998A6D67C2C4BAC71F6A8FF5AC8E3389FD93F35FDBA8E1A76EF6E9BE1A161AFCEB935915FC3D38B720D006215CF01661F0EE831F714CA89A04B01086AE417C745085F295584716AF4E6C3782D2E5B94BFE50B4E06C59A84C0D67F49A485B87745BBFDA3F004CFC76D59BA4400E0C7DF658CE9647FE62002B87DC8A69F3788F058ECDA851BDB4E6400B80C5908489BB170D6F97F1D2DC14E77A53E2423CEA4596FAE5AA7A961C1D9963D2DC4F399D38CB6AECDE5DBD8DAB1F864C716108931FE9AE76D98E1024B9FB019C9CEE932735672D50C6572B5ABCD089A9BE5E6CFBE8640425A6D557AA8972626C3B0598BD26BB64E2770FD84C14C7A863B922C72F875207A7688F4355BE44223C058D8094B2EF1902B5A57C174CF48D503490B709597299F369DFA769393AE0B072E7E3CAA585F371F7AA6D19A71EA0D434D90D680D2491C103846676DECCC30FE05D5E999F4F1C12EFFC34B1DA5BCD41FBE630D428B0701DDF316FAF5E72B32B3B7329CE9D8E657F6D6D4B64F8786E147CB42017ABECD8DDD528E71B70D8C73C79BCD2F442CEAE7267876ED136611B27A773C67CA1BF3C3C1FDF302D020A8852BDAA9E623451D47FD6C8D57240A1C871D4ED1D665790538AE66AECEEBEC645C29C1AFE53C907AFB44DCA292836EC33B2BE5E35683FEF8EC7A0E081EE6ADAC31843A79E6D668AB437D32E6DE1D4DA2FAFAAD7D367DB7EC2E3ADC5E1145F0590785D414C54623E0685C56E5E0FFE46089486B464CAAC321ECF397635F29BCCDC2C872A3BA55BA1D88D369343D70F8FF7D4F26CBB111D1B1707F7CC49AEEDF8678895512CCEDB4999932CD41D327FBF191FF881AC35F19B6C62C246E845BF233C70094A900DE269EDB536FA5C6117E72908037728C2FF55083CE71344488A3A6107FBF65B4162572E6E4C2CA31F7D8BEF1BEA1912CDAAFC01F510CE766B494B21DF46019707D3FB740360D5E550C7C4BF7A9E9A4F8479474CE916280C2F00BF14A94FC50B96EE7C32F2B92BC983FD680C3A9EC1A52AA68FF069CCA088C0F4C428CB3C18B544D1AE6FD17A8E8DD5DAF1667F32E706EEDC6FCE616AF56F1AE134D8996140F9F1BF862D43CB7568D84E40CD18E9DB5BC0E7B3876EC106E47587DB7C922385522BDEEEC2B6B4BB189CF25B0A0A7DE34974B0782C593ACB333D580AD929076D9BBC85B99D4ECFE9E220972306A317CAA59420F70F9454FB5867130B84FEBA578AC644FA00C138D8334C9F4EFAA595E31963926705524AF247420741AA68DA6236CD045EF59A635EDC77B17B8081DBE042987B2F5B8A91D58BD46A8271EFBC171E87BFE9A70EDC4E881C3C554A3492A1840C7CD4D685427416A035AEF54B359FB6FE81681E0258BADF2B6E429EC818970E62C1CF7BDF45C7678BFE82920B495A55841A0F86EB4E71E6AA85ED69A82DC23FC573F8C0F45FCC071ED398A0A73A9A0CBE4B517E131A72DFB74284DE1202593B3B4BD46630498444FF36C69956BD8A29AF6A9BFA57DEF82574B061B21F88B8DCF423BA77167FDCE1CC9D3F0F72121745C86B2C9748B726531D0E4CB936C9DE00D4D255E8CD0523B65232759910CBC7369E8D203EF57C22818194F346F7107A49AD61652D28B5A253D3E6B6D0261322CDCAE9E2F52B970DE8D55CE1906C7F1B14683640F505EB22D875245E71E7958E51F4FDBE122B6DABCC2A4D994D62F992721B798D817512C69F86BA818F091B751CF3F964F542B413FDC174851A4B48B5A110B61324350A24A33DF49ECB1DBCF8ABE7D79DA62E8135346E8ED1FD8D21B3950732985D095DB427A6C2E3082E9151285626D7312C2FC149DF9BE60536935267A3CC4711A8A1979D2CE2FA35428901363003D00797202036DB86A78BFE816AD9A6DA30B2C23AB1452EC0646CC1F1276112CA4755AF53DCC784326932B855E0629BE96FF0BEF837C9A8A61078853FA9F60C88CD6620BF9EB8B1246AF432F79AA5EC783ABB6404CA6F7BAE865B949775E5736457A0428E5DB455BE1B58E272A75EFCCED1A9C333E433960DD00B1BF44701A1B0B2F5A8035377861E9B1A1741B1ECF2CEFD0FA52F6DA858CB7AF8B1D089D5714E006BF8280821EDF41F51B604526278B6A7F783838DC2388CB5F7A334BFE51E177352B6746AAA74AE4E9817D85BE14BBD9CE2517D447373D1C10A6AC11A497CC17AB9B147BD33994E18BFBDFE5268B21CD77428294EC13BF0207158A72B1D1E9EE65908DB6B0C4DE6E6411DAA183C9BF779A24F4C1C8C1C00774559B514CAB68B0C81DB23D96216EF792496165F07DB8C256873BA0C204A327AF726E3C3B32AC57ABC31CE51D1341A81625C54F0CE61408936C7ABC892AC43230AF3AF64FCE52E34F7783A94E41B1F9EEEE6FF7388EA823491FE007F84F1DB7CFEB130AB839EE9EC7CB293F2782F200D0DEA15D15B169A77072F095AFB42E81F8742FEEF187C4C4D13199E2D4FDCDB074E3280EA453C4D9CE7B2D9F65E91974300CC7748BA49E9C797ED2B297E20CCB77247740066284B4C61C559CF655C5323C494A3CCB645761052CF59F4B5B54F3E0991C81036B5C9DDD0ACEA0365DA114FA72B0DD1F79619032234412E5998A325A6AC6143DCEB82300D0182127DF20D59A7252C79A9E228D3F955C7BE7A076EC5F031C018CC39CAAB83D081582AACCDBDB3F7F0B4DE3A08F1BBB68458B162F349182BB3BD152152727F8836B9FEA060D7394BEB2D42554883F93A8B81FD0B8E475EE1CCA8AADD9892841EBC81D720D11061C07D2EC8D505C8933F4A7685199D4F23E315E7D5848FEAB2F68B837397DAD3B29299A5CFEF9EAF48109F8A7BE7496E62699378C36DFA32C6C30407F99C8F9CC92BA123DE80CBAE9C2EF9B6FACBDD3132E21CF0A2F780C73C4BBA7C1AE43EAE648FDD1C3646770926D328D04157AF640C6498827060B55AAB1146BE347DB104F197E48EEDDA1DF657DA43976D8F82CAF7AC46EC5E6A26F5B254A21B6CA3C8A5A3E05AFA350D5DCA3D7A430B9BB7E1939ED119AA7A59BE6F10A683334009038F01534342FC0262114289D42884437ACB5F91EB8786801498C18839ED0B92161F106AC4B9E2FCC69528467423DD5881E478E1A38CE5ED59A960DE316360ACBB57CAF620D7CD428F58E1412974926ACA16A92FDA4A499171BF16A7AC2ADBCEA261189F10C87FBD061A80DF58D0CA6897DC7B83BCF1CEDC90F011BC334394CFA1F026227F8E691B3B47D8A6E0EF103E6F38E2E2A9F9365BD302CC252C0DA04AB849A0FF49E86E58B64C5A7F2A6371B1655F6CB821B0885B1F682D1C9CEC7D632CEBE2A3D62565324CE3A4CE395FF4E92C34ABBA1750B6A6BFD03EB1D3E492386E4B326F2D5C3C11E35B69066301688188C5B4FC2724552BEB17A8267B3F4628D58C2727F528C8E759EEC5391965FEE946F11BE9439916BAAC5AA5A9A68DA282686030A55E8CE78601A12B1F72DE57CACE42A82BA0350DF2DD0F7011C9E6C689276137930BC3C3E9C593F584F4A2732AF3F402653A36455148C1F242EFE0CBF1BEBBECF6AEC4A9087F8148C425A65C0B096E0614236A3A3BC217266E01BDD5FE0D1B9D69EAA50976E6DE0A0F5139B427BA3CCC0CEC8C396FFB6FFE3BEB59D4788B1E9C749A9775C2AB01933CAE93250FBA9BDF4E4B1A113E7F03F2445DECB0035CB81F9551328156F7D1EF86E9359F9419EDC0CAF88E398AA352CE761011214ACEDD659F245A86B7D0530789A5DBB53125F240EEC75D8ED5C0F33B577D4648A6717256938F7296CF8B55D44C470401001103C09A5FE2408B68061A1FC59EF9942D86D51B597B8D31F18328114D16B1F64927B45EEAD8683C73FE9B219D69ABC71D55776F5709695092B0376623F42659525CDB160C4B2D2375290E411FE4CAF7D54EA944D2F49EFDE5CDA276DE37B86FE89B9C52EA454917C296AB026EDAE09194C6F20685150C2D69220313BB6D204109C4F32E99BAD5472208AC90A4F299C4974877E54CD1E3C421FF2B7207224B2CEC9EF56BF4183CA19D896CAF2410663E60507028F172D4AB82FA58491597990EEFEF4B2FA00F5ECAB99DE8BA7E3AD12907CACABFB58E44094CED8C6A7F034D951025283B7247E59CC0374EC7DEC878FA9553EE953B8C55F943C257352E1709EF17C93AA3FFA87024C52BE3E213249A59777968E7ED27F8B12EB8A835661C3894B871B089D664F5AF3EF897360A95D94EBF9E9628D535DE6FA6D62F428709347DC53C5FB788E599221BDE0811BBB6FE743EF1026DF8E2AB10A139816B12828477BA1D168BF80E2F6545878E57DEF34A60F29DEEE3001C0F7BD3BB5AF9D3C22E5B8FA2A54E4935D365573E530D73DA68AE34AD344B177E0169AE4E4C517CEA8B223F44A8D008F22D8A1B6CB3DFEDDAF4251018D1058CF936F5BA752484F0726B36008D4E4B838392532924A49B02D8B06538E8D92E8EC912CB5C850192161248E813819696A69883DD346745721C8F760A18806933C178A63F9ABB2A1B9F95282CB1AF9CF8C5158AA5D76F518F2997D6782F7CA4CD588EBADA3BD58F9BF84A84392C536181C12F216F58EABCEDC337E39E6033D9DEA36EF23C85E3334F30EC6A6C31C468B7B132A90AD7A361DEF37B02AB3466AE27E" + "||DEC||";

            int len = fin.Length;

            int sent = s.Send(Encoding.Default.GetBytes(fin));
        }
        static public void test3_2()
        {
            byte[] bin = new byte[65535];
            string[] del = new string[1];
            del[0] = "||";

            string key = "1-54e9f5a0-de43";

            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress serverIP = IPAddress.Parse("127.0.0.1");
            IPEndPoint server = new IPEndPoint(serverIP, 12764);
            s.Connect(server);

            
            string fin = key + "||" + "3C3F786D6C2076657273696F6E3D22312E302220656E636F64696E673D2253484946545F4A4953223F3E3C726573706F6E73653E3C67616D65746F703E3C646174613E3C6D656574696E673E3C73696E676C6520636F756E743D223022202F3E3C74616720636F756E743D223022202F3E3C2F6D656574696E673E3C7265776172643E3C746F74616C205F5F747970653D22733332223E2D313C2F746F74616C3E3C706F696E74205F5F747970653D22733332223E2D313C2F706F696E743E3C2F7265776172643E3C2F646174613E3C2F67616D65746F703E3C2F726573706F6E73653E" + "||ENC||";

            int len = fin.Length;

            int sent = s.Send(Encoding.Default.GetBytes(fin));
        }

        static void Main(string[] args)
        {
            test();
        }
    }
}