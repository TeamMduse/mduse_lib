﻿using System.Collections.Generic;
using Unity.Mathematics;


static class Colors
{
    public static readonly Dictionary<string, int3> AtomColor = new Dictionary<string, int3>()
    {
        { "H" , new int3(255,255,255) },
        { "O" , new int3(255, 13, 13) },
        { "C" , new int3(144, 144, 144) },
        { "N" , new int3(48,80,248) },
        { "S" , new int3(255,255,48) },
        { "P" , new int3(255,128,0) },

        { "FE" , new int3(224,102,51) },
        { "CU" , new int3(200,128,51) },
        { "MG" , new int3(138, 255, 0) },
        { "Y" , new int3(148,255,255) },

        // --- menos comunes...
        { "HE" , new int3(217,255,255) },
        { "LI" , new int3(204,128,255) },
        { "BE" , new int3(194,255,0) },
        { "B" , new int3(255,181,181) },
        { "F" , new int3(144,224,80) },
        { "NE" , new int3(179, 227, 245) },
        { "NA" , new int3(171,92,242) },
        { "AL" , new int3(138, 255, 0) },
    };

    
}
 
 /*
 
13  Al[191, 166, 166]   BFA6A6 808090          696969
14  Si[240, 200, 160]   F0C8A0 DAA520	  	 	 	 
17	Cl	[31,240,31] 1FF01F 00FF00
18  Ar[128, 209, 227]   80D1E3          FF1493
19  K[143, 64, 212]    8F40D4          FF1493
20  Ca[61, 255, 0]  3DFF00 808090          696969
21  Sc[230, 230, 230]   E6E6E6 FF1493	  	 	 	 
22	Ti	[191,194,199] BFC2C7 808090          696969
23  V[166, 166, 171]   A6A6AB FF1493	  	 	 	 
24	Cr	[138,153,199]   8A99C7 808090          696969
25  Mn[156, 122, 199]   9C7AC7 808090          696969
27	Co	[240,144,160]   F090A0 FF1493	  	 	 	 
28	Ni	[80,208,80] 50D050          A52A2A 802828
   
30	Zn	[125,128,176]   7D80B0 A52A2A	  	 	802828	  
31	Ga	[194,143,143]   C28F8F FF1493	  	 	 	 
32	Ge	[102,143,143]   668F8F          FF1493
33  As[189, 128, 227]   BD80E3 FF1493	  	 	 	 
34	Se	[255,161,0] FFA100 FF1493	  	 	 	 
35	Br	[166,41,41] A62929 A52A2A	  	 	802828	  
36	Kr	[92,184,209]    5CB8D1 FF1493	  	 	 	 
37	Rb	[112,46,176]    702EB0 FF1493	  	 	 	 
38	Sr	[0,255,0]   00FF00 FF1493	  	 	 	 
	 	 	 
40	Zr	[148,224,224]   94E0E0 FF1493	  	 	 	 
41	Nb	[115,194,201]   73C2C9 FF1493	  	 	 	 
42	Mo	[84,181,181]    54B5B5 FF1493	  	 	 	 
43	Tc	[59,158,158]    3B9E9E FF1493	  	 	 	 
44	Ru	[36,143,143]    248F8F          FF1493
45  Rh[10, 125, 140]    0A7D8C FF1493	  	 	 	 
46	Pd	[0,105,133] 006985          FF1493
47  Ag[192, 192, 192]   C0C0C0 808090          696969
48  Cd[255, 217, 143]   FFD98F FF1493	  	 	 	 
49	In	[166,117,115]   A67573 FF1493	  	 	 	 
50	Sn	[102,128,128]   668080          FF1493
51  Sb[158, 99, 181]    9E63B5 FF1493	  	 	 	 
52	Te	[212,122,0] D47A00 FF1493	  	 	 	 
53	I	[148,0,148] 940094          A020F0
54  Xe[66, 158, 176]    429EB0 FF1493	  	 	 	 
55	Cs	[87,23,143] 57178F          FF1493
56  Ba[0, 201, 0]   00C900 FFA500	  	 	FFAA00	  
57	La	[112,212,255]   70D4FF FF1493	  	 	 	 
58	Ce	[255,255,199]   FFFFC7 FF1493	  	 	 	 
59	Pr	[217,255,199]   D9FFC7 FF1493	  	 	 	 
60	Nd	[199,255,199]   C7FFC7 FF1493	  	 	 	 
61	Pm	[163,255,199]   A3FFC7 FF1493	  	 	 	 
62	Sm	[143,255,199]   8FFFC7 FF1493	  	 	 	 
63	Eu	[97,255,199]    61FFC7 FF1493	  	 	 	 
64	Gd	[69,255,199]    45FFC7 FF1493	  	 	 	 
65	Tb	[48,255,199]    30FFC7 FF1493	  	 	 	 
66	Dy	[31,255,199]    1FFFC7 FF1493	  	 	 	 
67	Ho	[0,255,156] 00FF9C FF1493	  	 	 	 
68	Er	[0,230,117] 00E675          FF1493
69  Tm[0, 212, 82]  00D452          FF1493
70  Yb[0, 191, 56]  00BF38 FF1493	  	 	 	 
71	Lu	[0,171,36]  00AB24 FF1493	  	 	 	 
72	Hf	[77,194,255]    4DC2FF FF1493	  	 	 	 
73	Ta	[77,166,255]    4DA6FF FF1493	  	 	 	 
74	W	[33,148,214]    2194D6          FF1493
75  Re[38, 125, 171]    267DAB FF1493	  	 	 	 
76	Os	[38,102,150]    266696          FF1493
77  Ir[23, 84, 135] 175487          FF1493
78  Pt[208, 208, 224]   D0D0E0 FF1493	  	 	 	 
79	Au	[255,209,35]    FFD123 DAA520	  	 	 	 
80	Hg	[184,184,208]   B8B8D0 FF1493	  	 	 	 
81	Tl	[166,84,77] A6544D FF1493	  	 	 	 
82	Pb	[87,89,97]  575961          FF1493
83  Bi[158, 79, 181]    9E4FB5 FF1493	  	 	 	 
84	Po	[171,92,0]  AB5C00 FF1493	  	 	 	 
85	At	[117,79,69] 754F45          FF1493
86  Rn[66, 130, 150]    428296          FF1493
87  Fr[66, 0, 102]  420066          FF1493
88  Ra[0, 125, 0]   007D00          FF1493
89  Ac[112, 171, 250]   70ABFA FF1493	  	 	 	 
90	Th	[0,186,255] 00BAFF FF1493	  	 	 	 
91	Pa	[0,161,255] 00A1FF FF1493	  	 	 	 
92	U	[0,143,255] 008FFF FF1493	  	 	 	 
93	Np	[0,128,255] 0080FF FF1493	  	 	 	 
94	Pu	[0,107,255] 006BFF FF1493	  	 	 	 
95	Am	[84,92,242] 545CF2 FF1493	  	 	 	 
96	Cm	[120,92,227]    785CE3 FF1493	  	 	 	 
97	Bk	[138,79,227]    8A4FE3 FF1493	  	 	 	 
98	Cf	[161,54,212]    A136D4 FF1493	  	 	 	 
99	Es	[179,31,212]    B31FD4 FF1493	  	 	 	 
100	Fm	[179,31,186]    B31FBA FF1493	  	 	 	 
101	Md	[179,13,166]    B30DA6 FF1493	  	 	 	 
102	No	[189,13,135]    BD0D87 FF1493	  	 	 	 
103	Lr	[199,0,102] C70066 FF1493	  	 	 	 
104	Rf	[204,0,89]  CC0059 FF1493	  	 	 	 
105	Db	[209,0,79]  D1004F FF1493	  	 	 	 
106	Sg	[217,0,69]  D90045 FF1493	  	 	 	 
107	Bh	[224,0,56]  E00038 FF1493	  	 	 	 
108	Hs	[230,0,46]  E6002E FF1493	  	 	 	 
109	Mt	[235,0,38]  EB0026 FF1493
 */