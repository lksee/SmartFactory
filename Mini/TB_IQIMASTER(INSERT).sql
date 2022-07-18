INSERT INTO TB_IQIMASTER (PLANTCODE, INSPCODE, INSPNAME,   INSPTYPE, POSpec, LSL,  USL,  REMARK, USEFLAG, MAKEDATE,  MAKER)
     VALUES              ('1000'   , 'A01',    'ÂïÈû',     'V',      '',     NULL, NULL, NULL,   'Y',     GETDATE(), 'KFQS13')
          ,              ('1000'   , 'A02',    '±ÜÈû',     'V',      '',     NULL, NULL, NULL,   'Y',     GETDATE(), 'KFQS13')
          ,              ('1000'   , 'A03',    'Á¢Èû',     'V',      '',     NULL, NULL, NULL,   'Y',     GETDATE(), 'KFQS13')
          ,              ('1000'   , 'A04',    'Ã»Á¤µµ',   'D',      '55',     10, 20,   NULL,   'Y',     GETDATE(), 'KFQS13')
          ,              ('1000'   , 'A05',    '³ì¹ß»ý',   'V',      '',     NULL, NULL, NULL,   'Y',     GETDATE(), 'KFQS13')
          ,              ('1000'   , 'A06',    'µÎ²²',     'D',      '12',     10, 13,   NULL,   'Y',     GETDATE(), 'KFQS13')
          ,              ('1000'   , 'A07',    'Æø',       'V',      '',     NULL, NULL, NULL,   'Y',     GETDATE(), 'KFQS13')
          ,              ('1000'   , 'A08',    'ÀÌÁ¾ÀçÁú', 'V',      '',     NULL, NULL, NULL,   'Y',     GETDATE(), 'KFQS13')
          ,              ('1000'   , 'A09',    'Áß·®',     'D',      '13',     11, 15,   NULL,   'Y',     GETDATE(), 'KFQS13')
;


SELECT * FROM TB_IQIMASTER;
