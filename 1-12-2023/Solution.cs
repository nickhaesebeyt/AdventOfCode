using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode._1_12_2023
{
    public class Solution : ISolution
    {
        private static List<string> boos = new List<string> { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

        private List<string> case1 = new List<string> { "1abc2", "pqr3stu8vwx", "a1b2c3d4e5f", "treb7uchet" };
        private List<string> case2 = new List<string> { "ar0plr0Sevretwnmeoneprlokla", "6etera6sEvEn", "Eightpra9ltor0", "melko98834prosix98374l95lpp", "ol3pole", "onetwothreesixpl8rdtped9087onefivesevennine" };
        private string question = "9sixsevenz3\nseven1cvdvnhpgthfhfljmnq\n6tvxlgrsevenjvbxbfqrsk4seven\n9zml\n52sevenone\n41onevfsgvssxnpsix38four\n15ninedzhkpfstrscggbqhktwo\nrxbfsvhpnjvsixmxfhhmvdvg26rgrfj43\ngcbq2sghsv4fiveeightrlhchsfs2hsrjknfz\ntworgqpdjzrzf7one\nfivefive18\nsixfztrcxmbzktwofour3fiveeight\n2g4stjrjjmbngvljfvg24\n5jkcdxkltwo71\nvhpttjh2\n3threegmsppjrngfive7\nktkgsvkthreevone2xxrxzgdqpnone2xnf\nllxzczt3seventwotwosix5\neighteighthvllljmgg82eightseven2\n9hcjzphpktwo76xfpdvnhklzthreejrzkdknhrktwo\nfourtwojrvzzctzs5eight2vlm\nzoneightthree2hvhfsprqxmlsix7onevn4\n56sixssevenfour5twonine\n58fourfour\n683\n8fourninenhfpz9eightptsnnb\ngddmrzlpn9\ng3qsbqmbhqqp1eightkjggcxpmzgg\n6bzjqs7nxpvgtwoseven\n271lonepxp2flbmbz\n5sgshnrfn9qxt8xsnhtdtx6\ncnhflx4sevensixonethree\n595six93\n6eight8jbtmxdqpj96mqkrdxt9tpbpppl\n68qvmgth371lqcrglmvqxtwonfk\nmbqbhpmhspsbbxgflg98zn\n8oneqzvdcrh\nkb6\nmhgvpmfgjfourfourtwo4\n81mvcgqxlktbpkkrsgbdgeightbqn65\nhlbhthree1seven9\nvqczmtvqsnd3sh63\nqrzngvmk8\nchpldqtkhqbvdvmnqd5\n6three6two\nsevensix4tjvkcfgpone98\n96zgpcq9four\ncbvksjgvvklhnksixfive7kmmxg\nthreeljfr1vzskggfvjsccc\n8pfourthreetwosix\nl2sbdcvngvmtzrtq\nhjdxfj94\n2hbhfbjfteightnr5sixfpfjkn\n2sevenjqlpprggjlkddqv9oneightpj\nfivebfmkdrrrdkclkscqmtwo6five7\nfourrp8fnbp9d1fl7\nsix8pffqfpjl2nine\n91sdjlghq5\nfivemrmcnjmfcnck2\nv1\n78htfvqsztlsixeight\n5zpjtbgpkvkxbgpsp3cgklflkhdteightwortv\nmcxqfgxt49sevenone9\nrt2dsvpf\n9dzxmfour76six\ntsbmbdrgmzsjeightonezqhqb5qn\nseven8zllmz\n373onefourthree\n1fourfivezthdcxfr\n996seven2four\n8smnghninezczdlzxxgf\n7cbqfzrmhxdmrdr94tz\n6vstr65tfivelmhjshhj\n248fourlckvrtnzz4sxdqpgkvh\nzfivejfgfgdhfrhr6\none2tworsmtnzfjhvvqjnp\n5threefourjsnfzninethreejrknzfn\nseven9nine\ngthree15fivemzpnqgttcq1\nfivevvvkgtvs3four4\nfive121three\n7fourn\nsixdnineqvfqglmn98516\nninesixrppx4\nthreesevenxbskhlqbone276\nfivesixfour82\ntmdnvgrkjxfour9\n61nine\nvtxpkcgb48jzx8rgeight7\ntwoonetwo3\nfour167bnbdtxq4xvdgckkpb2\nxgbxvx7ninehmvqlldtxls88qhztfldr4\n5qxsfdchthree41\nfournb5gfqzfrlnc5fivethree1\nt6fourh3\nninefgzksevenseven5sbcpnczgflqptjhk\n6three4\n5tnplthreeeightvsk2fivesix9\nthree8hcvnmvbhbtwo\n6jnfourdbcgzgfzczbc\nz53\nfourxzhgjfrrbmkcheightfive7seven8oneightb\n2fivehkhnbtm\nrptgktsnzvsslcvfsevensixfive72\n95chcvtxv4\nninenldnphcpn93fivetwo7\nthreeeight675vmhvgtxxc2bp\nhfdmpv6\nxpffsljjcm27\n8sevensix8\n7hmszcvzpf9eightqqxgjdnhpfour68\n2czrnzdpxsjsdldcxq2vzgfrthsssix\nfour5bdxdnvtgcbdzzsxjdlbckninetwo5\n35fourfive6\nz5eight3r84hvptgskcclbsgh\n2eightljldmconeeightgvhm\n4sixsixsixfourthree\ntnnthreelfmhone1onepfivevdg\n8nine9lmpptxstrrbqbjrjtm4seven\n2ltqd9mnrbhcsprz\ntwo5ptcjzbqnk2spvlcxqvglndgvrlm5fiveeight\n52sqstnqpdeight55\n2nvskvthreeqhkqvjzqrk1\ngbkqz127four\n8zmngr5381rb\nklrlqvkhslvbxdtwofour4cmlpbdm6\neightninenjnmc8zrnrltgfmfour\n38sv7\neightvtkkmhhninebmgdvconenine7sixjkdzxcr\nh14bdgvknbnjq4fv\n74svtwo\n7three5sixone4\nzseightwo6five\nshkznseven5ninefivefour8\nmcmztmrgctqszzpqs8tworfvkseven\nonejjmdfour15nine4\n7bxqxxxvlthree4tb9five\ntwoqzpx6hj\n68hbdjdd45two\n68\n4hxlfbgvtdmbhnpfzxpnltfivemtmczjcbffour4\nfourseven4hfffmtqoneglgnnsrqsmbnxr\ndhbbmcxtv7five9ffjjcmshv31seven\nfoursbgvhgbggnine6three4zznzcvmxxqktpdhff\n681cvdh\n3ninefivefive\njg4dnnxzdtwoqdbvfsix\ng4dbeight6rkc\n236bjcppxmlnine\n5crthreefive8\n6twoknqfbmeight5c\n64eightrkvvtjtsonefour9eightwoqxq\nsm7sixfivexbrkvhtl9\nthreeninetwotwo1one\ntjjeightwoj3gsdmdseventwo1\n63sevenk4blssxzkcq29ztjlnx\nckpleightxgngnhkj2threem\n8knckxzrfbbpxldzninennnmkxkzzstsflv9two\nrmldrlcvccgdbvdnxvqr3ninefznpqrrtd1cfpjrvjzs\n5twojdflbxnlslnsjtklqkrbklvkthreejgxkfzeight\nsevenxfpzvss6\none61\n2seven7eight\nfivefive5fourtwo9vjmxmtpv\n4pxfour\ntwofive1eight9ldjbfbzhhffdb\nonefive7four93pjchnkrzvz\n4194hgfslhdczj1ztjtnccpjseven8\nsixtkjmtcthreezjfcgbdhvqlmbpzmc7\nnineeightvnd55sftvbf4sevenrkgbjskxbj\nkqoneighttpqcnsphsfour7eight9sixthree\n5foursvfsztnfivekkkftdfbptmrgcone\nsevensix8one5zjlfcrqzvp\n1hmvpbhzcbgbgvdkblnhgklltxx\n55xszsjgbd2fk\nhdrhmddj6ninebcfhbd\nf91six\n3tltgktntqpkeighthbqhlxcqnffgbfvxrkmr2\n3jthree\n2eightplclghthree\n771\n5gccqqmzmx81twob\n6pgnqbsqglk44mvslnxghckcbtffxvkq2\ntwooneone5\ntwohbxsxj2six826hlkdjnnz\n17tbdmntksvn89fivethreeseven\nsixplznhmbgzmlh3six1\nh2kvpbnkcxrssevenfive\njhpmnksix7fgnbhgv8fztxfrpfvmnrvhzr\nvskpbnine3vjqdlmv9\nvmg86ht36sbnzphxfive\nklqxeightnine6\n4nfninelzshl26\nzqsb243hfdtvgx\ntwo9tzcrmrsix81xsgvldl\nggqeightwo5bdpqtjkgzdclxsqptwo1eight1\npvfzftdxqzfourmmbzlbzcfsevenfivesix5\nfivelt5fivegshvshpvkpqlddmfj6\ncjpzgsvgsz7kzcpr1sixfour\n8two4onesevenseven7v\nztwonefouronezdvggfive8eightzflpvlnxfspgrtwo\none7tphmqvfltwo\n49seven2three\n9rntqtxseveneightgflqzkrxhglrnvrvz1\nfour6nine7\n5nine3\n4ddpkhft12hrhjvbtdxthree1tpknk\n7k\nfmlrpkxqktzdldrs84onefptgdjspldljvnine8\noneseven4nineqbqlbxf2kqnpr\nffivetwo97mp\n47h92ffcd6\ntwo7tcjvxdvctfivepcqxjnzfourfcndmdmnjseven\ncjdjxmnmpqr6cqvcscdpg\nonefour95\nseven9onenine\ntrpvv6six64kfmxqrdvbsevenhqzk9\ntsgpcfxsgsgmhd7rvfz\n66788\nfive26b\nchcbxone1\n6mrlfkqjssdxbtzkshvc8hjltjjxthkl\nfour5sdsevenvztqmzkm21threenine\nsnxrlctcztlbntnxkpmbs2\n652nnhvz6vcgx\n2zrxljdgsnnfour5fourp4\n85lzkjln55239\n51fourrnbkb4\nxbvsjmgsjdvhjpxdjhl1\n6sevencfhtbm4svgpzeight8three4\n827cclvxpdgqlhrjvrgxbxthree\n8pgqr\nthree2ninesjztqjdhdv\n538one59one\n6lcmxone4ninehzzb13\nphckzkgtxdcnine8onefour744\nfive61\nskbknb9qknrlszdt\nfivenine6jnxfsseven7\nlfj2onethree4198\nbb9\nkfljcb5zssbrlzml\ntwohmspvflmxnine2eight8\n4onegfnxxqpqnfour7\nqvg7seven4\n85bheightghccknine1three\nfivedpthreeseven1fiveseven2\n6nine3gzlbtvtvlnine6eightmdn\nseven3seven58gzmdjmchdrzxgkgbbfrf4\n2lxbnnsixgdcv6hrqjnfhdmz\n8threefiveflbfmthreegtvckvpxkd856\njbnkkbvfivexqzm238zxvztfl\n68kglf7\n9fivetzjsixkvfrngxbfbbjpd69\nninejgz82fivenltntmfs6xpxc\nfourlseight3qrrrrddzlone\nseventwoqfkj2qxzddcgtb348\nxgjddt5\nq8bfhspkgmsevenninevdqmlzxznhmdlg\nqc2sqqlkfrkj652xpgzjskr3four\ntwo3tpl1cvmldrrghr\nqhoneoneseven9zfivevrkkjhtdf\nddjczzpcvkksjzdcmxkhmbds2\nqnvgskzdb3nine77sdvfhfqsnv2kjffgsvz\nsix8three3vbpnkb\nrgjmvgtgfour36qqbqznkjv78cbpdqb\nfournshtzbqfourthreefive8hsbpflngrvzdhone\ntoneightone9four\nfourkkxtzpfivetwovnvxmtkeight4t9\ntbxlvkc5vgcmdckzv\n7threethree\n9ntqnzpldshfqlc2six\n8zs7five\n3threethreentqthree\njmxjl4four5\njnmrhzpdvbvvg9qcxjjmv2msrszndl\nonezjrkeight4two2seven\n32jlkhszgnkklbrsgpplphh\n1gsdqlbgt5eight1\n219\n93gcgx2twothree9xggt\n5fivenine1fiveplgmlffsvzbtqpb\nqv7lthszlgxeightnine\n7sevenmhmkcrkkq\nmxmmgqp4rptkbhfourvjh\n3mrmhgjmdv6pvfkbmconelmlckqkxjfiveznxg\n7one1kbjnmtpskgsix99\nbsvjlfgrcvvhmnfjzktdeight9914\ncsfrjtwofivebcrcmggfpfsevenlmhncfb1two\n3five1vphfournine1kvfvzrtm\nnineeight3vxrdvttwo\nsnncrseventwo5sevencjgl\nngmgxnlsjjhvqpcxjshninesix63\n4threeone2twotzsseven4prqdrnjln\nfivegfmn391\nthree5xflqlnrjgfpzt5\n28two\nsix729twoeight7\neight11\nsevenseven1fqcsevenonekrgxmone\n8rvlj62\none3ninethree\n89s6two2twofive\npnhhshxqb312\nvlnj5eight9\n5seven5eights3eight1\n6kqvkbjrfveighttwo6\n5twofour\nztnkthreefive1fivetwovqjpx3three\nqs2\n2vft3\nzjr1zjpxndcsc\n76threesix\n1four88n7\n9mrrkjzlxdc\n1ll89\nfgvcseven81\n4789vtvtcseven\n2lcfbmqcqt\n5sixonefive\ncdoneight1onetwo96lpllgksff4hrzjkxng\ngntghdtwo1\neightninefpdttgflvr2\n8zcnfm4krxhfive67seven6\n2hxpgvxgsmc\ntrlvltteighteightrzkxntpdtpl24\nhkttzcmnck7s1seven\nsevensnmhgdxpbksngnflnthreemlqgdvphzk5tvmzjvdzbcseven\neightpsbcshqcbppkgfxcnrgtwoeightfour6four\n53xktsrztnxninehpjjjktqnsixfivefive7\nsevenonebkdseven1seven\n11sixzdqbbppninehhkpxdbmlv2chddf\n3one3fivesevenlljjmxvzbcnqtszvzspsevenb\n1txlrnsb1vq28kpvv\n1two855\n2lxzhcjl1qfslvldkpdcxf\n9seven3fcqtzfive\neight4phtznrb69xqbmxmdvxnsstnine\neightfive2sixnhxcffkq95\nfive28cppfive1two6\np8\nkn8\n6hvzkkr4nine2seventwo4\n39134\ndztwone3kqlbbbknfive\nxvvdhddonekcgqqqzgxhlg2seven\n237rhppmlcmhsevenvnjxhzfnzbzrsdl\n1kgq1qsphhpcdeightjnfsdggnlnckgfbj2\nbnvpzxtnt16two\nmkhvcrfqdtwo3qfmhs\n1hkjncflcz5four7bbgpgcmnv94seven\n7seventmmhfgngfxt4\n98238\n3zmnhxqjqhjtptwoqtptmxfdp3seven\nbkqxlrtf4\nonefive8tvb6fiveone6\n1four3seventhree5mvsbsdjz\njtjsjflv5gxvhdgvrbgbdcjjtchkvmf\nsixthreefcrbqzqs7psczkdc\ndc572twonejgl\n2xkrpz9dfslbjvmbdkgsixhkgcvdgktq\nfive114\n8two85\n9fbh79mqbfsxcnn1two6\n6one9fivetwo\ngsjljnkhhvqlmmvcthreemfcbnjsbkvzzsnkb7\nnine49twojdqjsfbzsixrhbjhn4\n3threesix1\n52six1twoseven\neight9dbb6hhjnt\ngsnqmninefivefbqcrlneight1\njxczccqqpxbcq8\n1ckvkgqtvqrpvdrfivejjhhfkxvvhfm\nsixdxgvgglfh4qzczn8jpgqmgbzkmcdjfnhmh9\neight7nine9\ntzqv6fivefourhfz\nsixnine2vkmdnkgtgnbbkcxvvsc2bf22\n78two41\nsrpeightwovrhmbnkpnsix1\nfourninemfcvlstbmflzqf9lgvlvrlff2srxpzvrp2\nkcgtwone9eight\n7three1onesix1m3\nrgk2fiveeightthreegckdbd9dml\nsevencx9onenineeight6\n9ninetwocb4thttbkqj\nfive26vrc2krtfivejpgdmtjg\n2ninethree7cnxbkpvthreefiveqclhc\n98seven28\nonetwosevensix9three8\nsevensix2\nninesixlrdgpbrzs7onedrtlqpfour1\npmvxzronexxxvbdrjr7\n15eight\ncrksmfive64\nonetwo6fivemqkddjfxndjfpzmeight5xzk\ngq3ninetwo9\n8mgkvbpmbzpd7\nxfbvzlbpvb79\nkkbrvppqcg5\n94dkngltfzs98\nrchmjsrh7onejcknbl\n9threesixxrbzjt\n3963seven48sixeight\n98992\n7zqd\nsevenseven814htznfour1\nninefivedfrtwoone5\nqzgrrng8six\n3742zsgbqgfvzlgsgfmxql86eight\nseven7zdfrhonemfhcfmclxj25three\n8pnhpnsqxh\n62seven\neightpfgmmdg945ksctbstnh6cdxvgqbl\n932zsnvmcone1ktfqfmbnsfive\ndglzhqjthreemzpm78\none7sk13ghnmvsrprg\njdvzccvczspscxj5rzzdqdd44txvprhqx\nsevengmtcflgvpzonecvmbtgknine7kngpspbg\nxmqk6jmhmdtvh2kbchmsgpjrv2four\ntntsjnine3jksrrvone\nxfzgbzfive3ninekmnjrlqkzq96foursix\n3xbcth723\nzbvtsrxh94s\nthreesix8mjchcpvmdgfive17xb\n8eightnbbzhfhf4fiveeightmnzqldztsnfour\ntkglxsb6one62rhzggrtgqxqnvjzfmb\ngtj2onempqp34qfjnlxtztvjvsv\n2eightzxdgc3\n32dgskjkh2\nsevendnvrcm5166\n5knxkkjh5\nfssjcvvckqjrcghcmlrkcvxl22\n2jbhdlfjtbfivetkjbjmtrgxrdmxsix\nfivedm8pzjfngzfsk35\ntwo31ldnvx\n5mfive9ggkq\nvqdhfsfkrpp44trqpnkqsdxvvdxc\nlkdqckshmn1rgrvtjqj\nttwoneqzmsxzskbbnkfh8onespphhmsix31\njknbnfvbf1snjscz5\nsevenvjn9\nninetjzhbdjsffthreecfctlsfrz2\n6ninedqmxfqxssbhrrffpdhjvhqtkxfour9\n6tlrxcvhtllkrhjxqt3two3\neighteightfive79\n5sixfive7bjlkninefour\nxrgrxsvm5bhcmzggbkrljnssxgpgdlv2four8\n1mxlnrtsjgdlcsncktrsfour\n8xtkgjjbtjfnc62vsshkjp\n91twoninetwo\nninefour5nbnnzhtfiveggrjf7zqzblbml\nsixfour42rtbvlpcnv4\noneczchdtwoglj9279\njfvv5rdkpzldsxh\nninexghzhdqk67\ngnllbntksevenseven7sixeightvgnfd\nqzqjxcqrs8fivesevenrnvnq9nqnchpjpmfkgtjqcsvtv\n6sixsixspzppcstlhqlssvt\n4hhfndc17rjrrzvbjj\nxm6sevenseven2fivendnn\nthreesixd6nrxmxgcbjfrtlmpkjnoneshmrn\nncnpmsixfour4two\npqvz9fourkkmfvzbjqbfour\nszspfourhsqkfkfcndcnineone5khdb\nsix29sixlkfbphnrzcjl\ncdtwonenine73\nmtlqpjcqcseven29\n8onekdvdmjbmbjtdngxhjjchdv7bvsbjqszlhvht\nfivevqnjsvnhvnine1kxcsjmzx\n6six32twonine\nnnsix5fcsrdvoneightcn\n11rzzpnrtnsevenmvnhgrsgngthree\n3fourjfonefoursevenbbfour\nfiveclfour7seventwoeight\n4zvzlfive7hkzhbqrleight8\n4eightthreemthreeq\n66nine\ndlnm59eight\nfourthreexvgpp7\n85sixfnrjqvmzmtbpxttrn\none2seven\n63fourztwofdssrbjbcvhltg7\nfdstgbg1qdznxnvftfvfnr6djj\n5dcmbkrlvsrfvbdfqfour\nxp6fourrcfxdnktdctwofour\n9three4threeone6\n8pjzglttwofive9\n2gsix9sixthree\nptwofive3t\n4hqkqzjkqddnnhxkrfnhgbkthreethree2\nthreedthcktqkcthree22\n2gdlntwoseven527tzxbzkdjbv\n6hbxrgxzcnlbnz6\nds7mvjbvfkn\nsixrpd7eightfour6\nqfoursspgghsflcrvqeight6\n94hxsj5\nbhhhnfnnkninexnjtjxrphrkc9mdmjp\npbttrcplcsrldftsgk4991threepcbhxxfrgjddpz\n6four1fgjmjcnj3nbxxnnxhjhv\n6onefourshbzqgxjnhpmz\n9onedvscbrdj5\njgjrpgcjztvkqseven8sznzl16dzrhmhnq7\nctlbzmcctmkzpqtsdztbmllqnoneoneonenine28\nznkkbdsix23msxkcs\nseventwo365one2nlmlbgh1\nmtzthdjtonezfsixms5mxjpftkd\nonenine8ksxnslf16njqldnnkjx\npzjl78nztcgnj211zxnmhxzrjjh\ntwozkf3fiveshpt\nseventwo387bnfsix\n2xvvtzthreexjfxxg4seven\n8vgjxlvjc4twoglhmpgtsbfonethreeqbpcfbmz\nmhlgjlbm68rmeightnineone\nthreezhldnzscqfour9seventfkj\ncnprmbrprlhmonesixlksvgzseventhreehdzh2\nsmp215344two\n5nineonefive8sevenzvlfrprdq\nrvf583\nfour8nine4crzpff\nrhnsqgnncnjzhpx297qmj18\noneqlx716452\nmg3zptnqbm\n4ssgqpsevenznzlnnsbjpxkfvlkrjckxrhqsevenzrgjlkcffb\nsix9fourshjkhspkcffiveeightqqkvktvjsmmnfrthree\nsixdljbtwoninetwo6ninesevenn\nkcjqfvldclrmsd52qn\n352one\n7nine7\n9fourjcveighth\n5twoz73\nbbsvvbjc1one5gtts3nine\nfour2six\n7nine5\nnxjfthslhc2sspz\n69onethreefour8nq4eightwoqh\n8mfpmmthree6eightbksq7\n98bzjlfjm\nsix541threepklngxmfthreevvkdgxpfour\nseventhree4ninesix\n7ninejkcxsixsixlvffhbkjkfive2rdnd\n9flxnpfddx68mfgnkkdqlonenblbszdvvbfour\nthreemfk22vf\nthreeninemh6\n88six\n4eightrtthree\n4rkjjgppc2lkvnhbnhffnrvqsj8\n65gdpxxz\n5fourfour6\nsix9m9eightfour\n21szgzbcg\nkrzfvtsgp3\nsix2threethreebskteight4twoeight\n58bjrnzbqg\n8eight4four3\nfour6qcrnthree2\nj8nine7gqlvtqxlzdtcbonetwo\nsixvlthree55seven37\n48sevengfgzczbg82\neightsix2qsqfgmsrscfive\nzpbxnxbnmjthreebmksffpkd7seight8nine\nvfvhcvnsevenkbnhxxhhc3csk79\n147threesixtwo\nhldlvjninehnqxd7fiveeight7sixkkbmjxnjf\nsix3gjbkbpgzdszl3f\ndonethree3seven7xvfgnthree\n3lgpzhzmfftwoeightjhlngfn6five57\n5fnfl6vkncfsrrrsmxsl\n7ss\nfive6gsncdxsixnhphl85\n3rklhfbkhfour884\nxsjseven7\n58mxlmsevennine7cssix\n1jnbbfourv\nr21kstwo\nzrqlghpcsixeightseventlnpnxpzv3\n887\nzeightwo3xzjvmqxpjtbvj\n1brtqrcvbrrqsqbpsl1sevenseven22\n4qcddseven\nmg3xxlgdkblgg1htdjtfthpv\n9eightwoslp\nggqvtwonsfsevenfour73ccmzkz1\n7rfjfqh9nine\ngnpnrzzkdtfcseven45hvv\n34one1\nxzkfl9fivebxhcxrmfzszonekgzcvk1six\n8pzscngsixsrtjqqlk25ldczspzfdxrzhh\nzktjxcb72twosix\n9mvtk5jqhtwo\ntwo82klbfdf\nxstrdlsmx2onesevenrmgpjlrtfsfourfive4\nfour1djgssbq8sixfive\nj1jkgzrjmnfxonejsvgzznsevenprbqbjn\ntwo65ffglkhgqb8xdxmldhtllj3\nlqqqsrjf27four9dgpjcgz\nfptvlnfzpfm99eight8five5xtgqt\nsgrdlpplhb2six6\none4811eightrvkbchcngmone\nbcsv46dgxglfxsrn9two\nspshpxtwo6c\n1sevenrtbxc23\nsxppftvvfx4qvhbrrpcgfb\nrmcvzcl8dj4ninenpgjhlblbeight\nthreeseven7lljggng5two9\nfour47bnnine2chscshsrone\nkxtknjfourjr1pxxkqlxjsix9\nsixtwoseveneight8sixthree\n8djjznt4\npj48hjlqfour7\nonedvpqsevensncd5fivenhftwo\ntwonls1fivednlbmttzszjczdjfqcspxpt5\n11hbdpbbrjddrmlghs\n7seventhreeonemsszrjxd\n4smtgkzzrxlcslkhlnrft14fbtznvq5six\nrdv9four39\nfour8fourvthreebrnmqmhb\nmsgrzsdxfxfivecpjqxtphffm3zvgqxkrtwo\n1sevenseven3vlcmzlgseight3\nthree1bkmpjqxsjmjsmlvhfrnine\n213sevenfkslf4ldg\nfivegflgdlqrfkmh81\njrkqklq5sevensevenddlzbljvf\n5zjxsxqpthreeone\nfvh6\n154xqxjfvt\n32fnpjclfgjplmkf83\n6nine785six\n5one9fiventcxnine37\n24seveneightrp\nhbd6two1knqnfgcftq839six\n6eightzzqghd\nfiveptonesixnkslhvpkpsbfltfqnnqjfqjlhthree1\nztdjmvrspdtbqsffive8onetwoblslmlxssjks\n876fivenhzmftccrcgvqnssixthreejhg\njpvxbhbrv55ninefive1three\nndpdvz2sevenn\ndkzpptsmbfhnnrqqtwodllstjtd87\neight1fivejftckmgxmzbsq416one\n2q16ninesevenfour\nthdst7fourfivetwosixgfjsnvftone\nztwone8tjlsrsqpnqsxfll9five39eight\nthreefive757nzddvxh6three\n71two\nnbgsnbdvqkqr6nvsqhr\nfour487eight\nmgqtnlqxpvbjrgqffourzbtvcxj4xht3twoone\nfourninefivefive97hzfxr\n4dhrgdrsr4onejzgs5x1\ncvnmzrdmtwotlvk4five\n7sixzghv5rxlbslsninefrsxht\n6lcmjnckbjrtwosevenvmtxcnfvkfqvgzp7\ndvndcdmtfxbtznqjrprksseven6twosevennine3\nthreethreeone11ninesixeightone\ndvvcbsix96cxhgjpmqdsixone\nfive4sevenmnzgktwo\n9rlsseventhree6xhtbxdnn\nbxlbjtmone15jsixeighteight\n1fivejlsevenmbbfksks\neightsix35fourgcptzrfjhkrnfbbznine\nseven8sixfive72eightqjmcfjx\nseven8616xszttt3seven\n53twoone22\nonefour9ninetsrvczrnbsbrfstwogkkzs\nzpsplntwoeighttwo49three\ntwoeightseventhree4\neight5twofourgpnlsmppt1\nfourccknqs7dndlqhbsdhfmqgr1lvnpmxjtnkshgm\nfive9ptrnrfdfgdkgxzlr6three\npjxgrrgmfk57hdgclbftr\ngdcxzqldf3z2prsmfivenlklnrtbhfst\n999\n85lctfptljktwobtfnfrttlxrvlfvdnbsm\n172\ntmrcrhkvnfsixkvzhjxmngcrfmkfpzqcfivermnkxlfive7vtvvmmnfsz\nsixseven6two8kfrpjksixeight\n75pzmmlvsjn9987dftrvbf\n4z1fivethreefive\nfoureightrdnnpxlnn32knstrmxg71\nsvzljxbj113zpnpshmnf\nhj2hmvp3eight38gxngvkdmnzzzcxjkl\ngnrhzjzvrzsix33vqnnrmgtdvvkbsmglckd8\nonelgjfczsevenninehkhkxcskvcvnncbpj5\nonesevenninethree1\ndqqnkzfv9bnine\n8sevensjtppblkhh4seven\nninekggzmfsfpbfnvtv3sevenczrhzztlsfour\neight59hkthhk\nblskkshczzone7\n6one4pffxsgmc\n4lrbncnn8\n314ninefivesevennine6seven\nthreeone3ccrfthz2seventwoctg3\nbfxknbtwortcfgnrcqsvqfcrxzmlmk83krb5\nfiveone8\nnine6661\neight8884zbdzcsseventwonexgg\n16ninetnzftqzlpvgd2\njxfccks1\nsixtfvgpjrvpr6pmsseveneightvbrxnq\n6eight5\ntdbs3cbfhglpfdnxlt\nnbcgkzchlj6pbcx4\n661\njcjggnnn1\neightdbtfgpfivecnlmnkrpgf1nine\n33bngjpkhgfqp4tl97one\n6rkmbdjztnfninecdlhnbnf6ninekmvxrqzbl\n465\nnfklpzppbq65threeeightsix9\n2gddbjlcdkx\nkclqnmpsixsix4fivepb\nstvlnrfdgcslqmveightbmbgmnzlrq8gfjndq6rsv\nsjzcfxn7hs\noneeight32nine2ghx2nine\n2lhx9\n6eightseven9\nthree9nineone7five\n1nrmk\ndccbdjqhvfoneeighthjsmfp89hheight9\nsixrfjshf9nhzngkgeight\nzsixone5fiveeightsix7\nvkthreesevenq42982\n2h\n8five9jkvqtwo9\nlkxvfm7qdhvnkt\n8jtttvnmxt\n1nine91sixsixfour\n8threenmffourone\ntwo2zjj39seventhree\nc4eighteight7hssvhvlm2six\n9eightfivezmnknpl5eight8seven7\nthreenine4eight14vzmmhczfhxppqs\nseven22fivehgtttqthreeseven\n5nineeightthree\nhfffcgvnkrp5threevccpjmnfn3\n19seventwonelj\n4nine8\n2sixfggckcdt91three6\n9fpztvd\npbm384\nrqxzzqtlsx8one91tjmqtcmkxhplcmns5three\nfour13sixgreight64\nseven22four\n2six946\nnine1767three\nmdpvkhvbqstqpskhdxgbzt2zsdvsclhlzbcskckz\n1775\npgdbfmvffninezhthree6qlrdkbvqthree\n29fourtwo\nfiveone14bsnrd\nloneight1fourpvcgxjsscssftbfxtkq\nfhtwobfnmvjxqzbzctxseven8lhxv\nninefive67rqvgnbt\n2fivesevenfive4rhpvklfjz9ninezszc\n616vvbxfjplsppgpx\nrttqfddgone3rcvdljn88jqrlbdmxgv4\n8282eightseven\nmkhxlkksgsjrczffqmzzsevenv7seven6zv\n5hvkqdnpgtzfjbqrtzx5tncqbmxjpqmmzcf9\nllpkjvonesixlnf7one8oneseven\nfive65qzjtwo\nxhcjxj1jghxktnmbxml5bbpklmdcthreedzt\nh3sevenonevdnjp5zpzfmch\nseveneight1mrrkcpbqd\n8one5rn\nqbffrljhl48qtg1jhngrrbsdhxl6\nndc5sixcxlcgxpbstwoqfffive5\nfpfsqrzfjthreehzbcmhss4fivegbtwo8\nnine2two\nmddbqdmtcjrkqhv2dxfvdg8eight\njbrkj2llgmg36twocvhmxnb\nmhdbsnine1\nfour1mcvjdkmthmhcsz4\n59fbsnx7qrtclvrkfoursdpmhdz\n6d6four27zeight\n1sevenvjbqrd\n9fourlmjqn9rd\ngfxsrconexrgdzrhzcsh4six\n4one5jhsztrspthree\nfour5eight2\nonebtwo4eightfourhkrsgeight\n51kjcqqxrjcnnine5\nkprdj25twotwovsdhzgmc\nhtwone4344five1\ndvmkvcfcpsqrh1\n9twogzkc572sixhktmslseven\nfivefive7qnll7seven\nsvbpx64n31onevzjhhhl\n8fbjkdcttwofourtwokj\n6twotwo5zkcnxczszfive32\nmbfcmsjmg9hmqngl\nninesixsgnfzsmbgrlxbxjstkmmfxc5\ntwo8fourthree9sdxzvpgseventwonez\ntd3two\nonespktrhrktzrcvdgqvdxgbgctdhjmm7shqcbzvfxhzlt\n5zfpfksszthtzxznxgkrpc\n8xvmsseven592ssmzjdmz\n64fkcmhmqdxnseven\nvdhkbktf1seven5\ntzfvfour3three\nfourl7four\ndkbbtpd5qbqgb\nqzdlttqfhn8chxxbnplt4\nqmd78hqdqxtx2rrdvkvvfourtwo\n91mmlbnbs5peightmznzhskfjv\n2rftqscv\n4oneonenineddktjvjlhone\nninetwo5four\n1f36xndmtmmbpx1qzqmdkpbp3\nhxsevenjg6fiveeightwodps\n4mrndsix18\nr6klzqlz\nndbrrsvp9\nsixsnkh1gvcnine5\nbsstxkninethree5ktwo7five\nfiveeight9five7\n3nine5sixkqlfrpdpcfive3\nlrrqkznlrcmbvdr6\n8xklphsevenonetworjgpjlrllgqcrxhlskfhpq\nfourmsthcgcxjsixcvnvninebdhttzm85\n8gnqnhptgkfivesix\n8onenine\nfivesixone3kpzvnbrjf\n9four54\n6twothreefthreefivetx\n4nxqzkkbgvthree7qxdhtpjv\nsix5three2ninesevenfive\n3cqkmxnbkkh6tnszgzxqk\n82tzncrpvjts7\n39one5fivenine\n51jrdstpqnjdfbbtjz9three6\nnqrmg8\n7threesix\none6fsxsflbnfivesixthree5\nbxbonethree55one\n7onextpttrflql6snmbdtbnvvfive\nthreeklkjkvqzone2vhzsqdg\neight231eightsix5\ncflpngxndfivefiveeight4rjrsfrmmtwonen\nthree8sdone\nnine4nine\ntwo2dxzjxkbb2knvg\nbplttc53\n69hqtkfivesixtwopffgltlsj1rhhslz\n6fbg1scccrkjjsnnhpqmphksevendt5pcdl\n9onesixsevenfmmxtkdzone\n1onetwocrhcqhrxt7sevenr\nsixeightxjjqndfqtwo35\n9cqvtmfsqrfqhhbkjgbdk\nfoursixfrtkpcbxgxx5one\n429three\n84mxhzmbdk8\nnine79\nxgntrzninemhxtqnine4ltvx\nfour3seven6qhrzznzctwofour\n5h\n16eightninejmddlknrxfone\n3gjpbjdone\n654twocbczrzjnhkgdpqdd\n2xkptbxsixnprkhfslj\n19mlqcgbfpdonegdvzghjjb\ndnslxvmdlpmlsggq1one18\nlbxnz487vjlhhsxvcl\nsevengvgkk8mfbplfshlhqnrvbtwofour\ndjfptvqgmkqgnzdvstwomzpcxfthvzpfsglc7\n1nlsztzzcbmqseven4fourdqq2\ncqcvkcthreeflhbcsbddg8\nsevensvtbtdkfkxzbfqznlh1\nsevenksn54\n4dzv6\nlsixninesevenrxn2seven2\nbsix2hqsvvvxvkpbg\nhplfzmghmbddz2htfkcfblqcdzfrvqpssbxdone\n19sqgxkn8four\n64ksmvcseven1748\noneoneonedlmsdc1mjn\n7218\n3xdskntkmlcldqjgxbgx38rkbddntz13\ntnqnvshmhrkxbjvxcvdhmx1\ntwocrzgfourbvtkcthdkrqpbsevenkfv8zczzszpf\nfdkdqfgbgnttlpnjrvnine6dvpdhtchfourbv\nqqrznptxjseven9twofourtwo\nhpdrqkonetvgfour5onepdk\n6eightsixninetclcsllxknspxfgxmlxqddvone\ntwosixmcbbjthreekclp3\nkklgzxnk2eight\nzgmnine8oneseven\ngmcgzggsixvjzzgrs3gbzmxninezrlcfsphzhseven\n7sevensix5fivefourh\nrh1qzxvcmqjmtspknine\n12threecjltwozchdsfnkmchhgv\nvktfhngfb391ghtnrqfourfiveone\n9eight46xdxkqtkflqdv59four\n839sonesix2btrctxfm\nhzpjkvqdfg6three2twocsq8tskmdnvdl\n5f\ndgmvxqbpbjpbronefivehlf8ls9four\nsixm7m8three\nvgppvrgdlb26623csvkhsd1\n2hjfccgbjnhl8176xkpftwo\nseven12vgdnrvmmp1\noneoneone7eighttworvpvsjzl\n738one99six\nsixrjm3\n15six44qndpslhnine8twonehkb\n912\n3blcn\neight81fivexsbkzcthree\nkdqlzbnbnkh2mrpz82six3six\nsckfhxxjxfivejgtlmdhc3threeoneightrc\nznjgdjd8six6onesevenfour4qpnmvtdnnf\n7gnbonesixninehreightlmjone\nsix3fhhlfgmdlgvhvqctcrxxh\n982vbjgptnc\nsgfnlppbvfzrmntwo9ggqzsixsixxgqvjvffour\nninenine8\nkzfmgls5seveneight2\n8ninefourzrgjgrqkxrmjlzqb5\neight7five\nfbjt4eight7rnhvfkl5knpvjhqdhvmvczxbvrx\n35five\n7gzjqslr13qsqxltsninetwoxmhgzhl\nthreefour2three\nonethree45\nzvt8nvxctwo6\nsevenkfournine1drrmrmljsclgbgsd\njfcnrxjjnbsrlblzpvxc84seven3six\nsevenonemt7eightseven6\nsevenrddndpj85fzzn4zhvthzp\n78zfdbmrfgeightgjtqnx\nninerdqndgffive2dlsblldpfthree9\nlvzlfqzsixeightkqbnlv5njjsc4plh\njsqhmbt1xvmkgfbghzdplkxdmgvcrkbngrjlpfj\nlfnvhdxcx7twoq\nfive85\n1two3two22bdpbskrlph\nninefc31fnhsnhf5\n2cxnrgtlvfvmvvmnfjllshmdvvfc48sevennjfk\nxbglffkvrzsmz1\nczlrrchbkhmz5qkdbtcjlffd5\neight65sn4\n7seven2four99mlpskrgoneighthm\n9kfpfgzdjdgxjkltdkbkeightmxteightthree\n9bdsbeightjvkrmhdkghfive73four3\nxeightwoninehcrsdbnvtwovtbkhtxktjslsix3\n15fourlgrsk\n5xjqd9\nfour8ttpzxpnrqnkz1\nfourvbfhg1rbrngbgfj6nineldqfxvrx\nsdpnkkfive9twodz23\nsixone4twoktcx\n8rjgbnxsixfivebsnthree2fivenmjxx\nfourddtxngtd4jvlttthhmz\n2nine95four1six9nine\n2gmxtrrkftjfnknknineqjqnscctfourzrqdrgs\nflghzhfgmn9tckbpmkgsix9\njg9svtdrmlzm31rsrqvc4mggcj\neightdpvfplptwofdgrkstvh8qseven87\neightfour2fourvzksqhxmlkpkfktmdzpmthreetwonehv\nnine86kzqvkjqtjfourmpcggd8\n8nstjmtmstcnffnksqh\nbvgcmbcrgqfourpvs5xs\n8three12\n5398db9sixvnvcrztrqz\n7one62fourlndnshczz522\nqxrhp5eight183tfour\nfhpzgkt81two57\nktlfdnbone6\nstsninecqxpfmdhk41vlpq\neighttqcc5fqnfour84\n25gmh12threeltfnfdrxhh5\n57four\nmqgdhfour67\n37ninetxkddhfive\nrzrsskzrlzjbcgthreeghbqhdpxfvgjfqclcf4\nfourvone2vbpltlrj\nxz5four3nineseven\n1szrhcmzkftwo9eight2ltjmgjzcblzone\nzlnkddtgsb1sixsxvjxgxp2\n26sixpzpsixtwozqff\nseven99fzqxfmttfgxm\n9twonineonefourpttbgkxt8two\nfv9\n5qcmjsfk6zxjld1\nfkjstnvmchsr9q699\nnine78three\n4rcs6bhbbgzhsstwomnineksbxfzj8\n4fmblhqninefive6qbkm\nzsgjbfrjfour1sp3\nzbfeightfive1oneonernfd\n5bxtfvzczbhtzfourqglqdxsc\nf9five7five8ddvseven\n23bszpdxfjmzg\nfivegctmd3vlcgfgnine\n63hbdkxljlq\n64eight6eight6gxdpmtnbfone\n28xcbtt1\n1six5\nfour289";

        public void Execute()
        {
            SolutionLogger.LogTitle(this);
            SolutionLogger.LogAssignment(this);

            SolutionLogger.NewLine();
            SolutionLogger.LogStart();
            
            SolutionLogger.Log($"Case 1 w/o Linq", "H3");
            SolutionLogger.Log("Answer for the following:");
            SolutionLogger.Log(string.Join("\n", new List<string>{"sevenine", "oneight", "sevennine", "oneeight"}));
            AnswerMeNowWithoutLinq(new List<string>{"sevenine", "oneight", "sevennine", "oneeight"}, out Dictionary<string, int> t, out int tt);
            SolutionLogger.Log("Answer for each line:");
            SolutionLogger.Log(string.Join("\n", t.Select(a => $"{a.Key} = {a.Value}")));
            SolutionLogger.Log("Total value:");
            SolutionLogger.Log(tt.ToString());
            SolutionLogger.NewLine();


            SolutionLogger.Log($"Case 1 w/o Linq", "H3");
            SolutionLogger.Log("Answer for the following:");
            SolutionLogger.Log(string.Join("\n", case1));
            AnswerMeNowWithoutLinq(case1, out Dictionary<string, int> case1Answers, out int totalValue);
            SolutionLogger.Log("Answer for each line:");
            SolutionLogger.Log(string.Join("\n", case1Answers.Select(a => $"{a.Key} = {a.Value}")));
            SolutionLogger.Log("Total value:");
            SolutionLogger.Log(totalValue.ToString());
            SolutionLogger.NewLine();

            SolutionLogger.Log($"Case 2 w/o Linq", "H3");
            SolutionLogger.Log("Answer for the following:");
            SolutionLogger.Log(string.Join("\n", case2));
            AnswerMeNowWithoutLinq(case2, out case1Answers, out totalValue);
            SolutionLogger.Log("Answer for each line:");
            SolutionLogger.Log(string.Join("\n", case1Answers.Select(a => $"{a.Key} = {a.Value}")));
            SolutionLogger.Log("Total value:");
            SolutionLogger.Log(totalValue.ToString());
            SolutionLogger.NewLine();

            SolutionLogger.Log($"Case 3 w/o Linq", "H3");
            SolutionLogger.Log("Answer for the following:");
            List<string> case3 = new List<string>();
            List<string> stringList = question.Split(new[] { "\n" }, StringSplitOptions.None).ToList();

            SolutionLogger.Log(string.Join("\n", stringList));
            AnswerMeNowWithoutLinq(stringList, out case1Answers, out totalValue);
            SolutionLogger.Log("Answer for each line:");
            SolutionLogger.Log(string.Join("\n", case1Answers.Select(a => $"{a.Key} = {a.Value}")));
            SolutionLogger.Log("Total value:");
            SolutionLogger.Log(totalValue.ToString());
            SolutionLogger.NewLine();

            SolutionLogger.Log($"Case 4 w/o Linq", "H3");
            SolutionLogger.Log("Answer for the following:");
            stringList = "two1nine\neightwothree\nabcone2threexyz\nxtwone3four\n4nineeightseven2\nzoneight234\n7pqrstsixteen".Split(new[] { "\n" }, StringSplitOptions.None).ToList();

            SolutionLogger.Log(string.Join("\n", stringList));
            AnswerMeNowWithoutLinq(stringList, out case1Answers, out totalValue);
            SolutionLogger.Log("Answer for each line:");
            SolutionLogger.Log(string.Join("\n", case1Answers.Select(a => $"{a.Key} = {a.Value}")));
            SolutionLogger.Log("Total value:");
            SolutionLogger.Log(totalValue.ToString());
            SolutionLogger.NewLine();
        }

        private static void AnswerMeNowWithoutLinq(List<string> case1, out Dictionary<string, int> case1Answers, out int totalAnswer)
        {
            case1Answers = new Dictionary<string, int>();
            totalAnswer = 0;

            List<string> wordsToNumbers = new List<string>();

            wordsToNumbers = new List<string>(case1);
            for (int i = 0; i < wordsToNumbers.Count; i++)
            {
                string wordsToNumber = wordsToNumbers[i];
                string replacedFirstDigit = wordsToNumber;
                bool done = false;
                while (!done)
                {
                    string previous = replacedFirstDigit;
                    replacedFirstDigit = FirstWordToNumber(replacedFirstDigit);
                    done = previous == replacedFirstDigit;
                }
                
                string replacedLastDigit = wordsToNumber;
                done = false;
                while (!done)
                {
                    string previous = replacedLastDigit;
                    replacedLastDigit = LastWordToNumber(replacedLastDigit);
                    done = previous == replacedLastDigit;
                }

                int value = FindFirstDigit(replacedFirstDigit) * 10 + FindLastDigit(replacedFirstDigit);
                case1Answers.Add(wordsToNumber, value);
                totalAnswer += value;
            }
        }

        private static string FirstWordToNumber(string word)
        {
            string toReplace = null;
            for (int i = 0; i < word.Length; i++)
            {
                char c = word[i];
                if (!boos.Any(n => n.StartsWith(c)))
                    continue;

                foreach (string possibleNumber in boos.Where(n => n.StartsWith(c)))
                {
                    if (word.Length - i >=possibleNumber.Length &&  word.Substring(i, possibleNumber.Length) == possibleNumber)
                    {
                        toReplace = possibleNumber;
                        break;
                    }
                }

                if (toReplace != null)
                    break;
            }

            if(toReplace == null)
                return word;
            
            Regex regex = new Regex(Regex.Escape(toReplace));
            return regex.Replace(word, boos.IndexOf(toReplace).ToString(), 1);
        }
        
        private static string LastWordToNumber(string word)
        {
            string toReplace = null;
            for (int i = word.Length - 1; i >= 0; i--)
            {
                char c = word[i];
                if (!boos.Any(n => n.StartsWith(c)))
                    continue;

                foreach (string possibleNumber in boos.Where(n => n.StartsWith(c)))
                {
                    if (word.Length - i >=possibleNumber.Length &&  word.Substring(i, possibleNumber.Length) == possibleNumber)
                    {
                        toReplace = possibleNumber;
                        break;
                    }
                }

                if (toReplace != null)
                    break;
            }

            if(toReplace == null)
                return word;
            
            Regex regex = new Regex(Regex.Escape(toReplace));
            return regex.Replace(word, boos.IndexOf(toReplace).ToString(), 1);
        }

        private static int FindFirstDigit(string word)
        {
            foreach (char c in word)
            {
                if (char.IsDigit(c))
                    return int.Parse(c.ToString());
            }

            return 0;
        }

        private static int FindLastDigit(string word)
        {
            for (int i = word.Length - 1; i >= 0; i--)
            {
                char c = word[i];
                if (char.IsDigit(c))
                    return int.Parse(c.ToString());
            }

            return 0;
        }

        private static void AnswerMeNowWithoutLinq(List<string> case1, out Dictionary<string, int> case1Answers, out int totalAnswer, bool ignoreWords)
        {
            case1Answers = new Dictionary<string, int>();
            totalAnswer = 0;

            foreach (string toCheck in case1)
            {
                List<string> separated = new List<string>();
                foreach (char c in toCheck.ToLower())
                {
                    bool isDigit = char.IsDigit(c);
                    if (isDigit)
                    {
                        separated.RemoveAt(separated.Count - 1);
                    }

                    if (isDigit)
                    {
                        separated.Add(c.ToString());
                    }
                }

                string last = separated.Last();
                if (!boos.Contains(last) && !int.TryParse(last, out int _))
                {
                    separated.RemoveAt(separated.Count - 1);
                }

                string firstDigitString = separated.First();
                string lastDigitString = separated.Last();

                int firstDigit = boos.Contains(firstDigitString) ? boos.IndexOf(firstDigitString) : int.Parse(firstDigitString);
                int lastDigit = boos.Contains(lastDigitString) ? boos.IndexOf(lastDigitString) : int.Parse(lastDigitString);

                int value = firstDigit * 10 + lastDigit;
                case1Answers.Add(toCheck, value);
                totalAnswer += value;
            }
        }

        public string Name => "Trebuchet?!";
        public DateTime Date => new DateTime(2023, 12, 1);

        public string Question => "The newly-improved calibration document consists of lines of text; each line originally contained a specific calibration value that the Elves now need to recover. On each line, the calibration value can be found by combining the first digit and the last digit (in that order) to form a single two-digit number.\n\nFor example:\n\n1abc2\npqr3stu8vwx\na1b2c3d4e5f\ntreb7uchet\nIn this example, the calibration values of these four lines are 12, 38, 15, and 77. Adding these together produces 142.\n\nConsider your entire calibration document. What is the sum of all of the calibration values?";
        public string QuestionInterpretation => "From a line of string, create a 2 digit number, combining 1st and last digit. If there is only 1 digit, than make a double digit number from that one (e.g. '7' is '77'). Return the sum of all 2 digit numbers for all the lines.";
    }
}