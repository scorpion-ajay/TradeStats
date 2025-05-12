# TradeStats

## Available commands:
  process <full excel path in double quotes> <sheet Index in excel workbook> <count of top rows to skip>  - Load and process Excel

  print  - Print all trades

  save  - Save all trades in a target file

  exit   - Exit the app


## Example for Process command
> process "C:\Users\aries\Downloads\tradebook-AL8984-EQ (2).xlsx" 1 15

[18:30:10 INF] Processing tradebook from c:\users\aries\downloads\tradebook-al8984-eq (2).xlsx at sheet position 1

[18:30:13 INF] Processing 2103 tradebook entities

[18:30:13 INF] Tradebook processed and trades derived


## Example for Print command
> print

[18:55:22 INF] Printing all trades...

[18:55:22 INF] Total trades: 59

```
Symbol                 Qty     Entry      Exit  IsLong           EntryDate            ExitDate
----------------------------------------------------------------------------------------------------
TBOTEK                 400   1188.87   1191.90   Short          2025-04-01          2025-04-01
PANACEABIO             300    463.28    446.30    Long          2025-04-03          2025-04-03
NMDC                  2000     70.47     69.20    Long          2025-04-03          2025-04-04
PCBL                   400    440.46    429.70    Long          2025-04-03          2025-04-03
KIRIINDUS              300    652.62    627.25    Long          2025-04-03          2025-04-03
UNIONBANK             2000    128.31    126.10    Long          2025-04-03          2025-04-04
AMIORG                 100   2533.10   2497.65    Long          2025-04-03          2025-04-03
AMIORG                 200   2532.30   2461.95    Long          2025-04-03          2025-04-04
SBIN                   500    775.93    778.66    Long          2025-04-03          2025-04-03
SBIN                   500    778.95    768.05    Long          2025-04-03          2025-04-04
SBIN                  1500    779.67    778.63    Long          2025-05-07          2025-05-07
SBIN                  1500    776.20    776.88   Short          2025-05-07          2025-05-07
SBIN                  2000    776.35    775.49    Long          2025-05-09          2025-05-09
POWERINDIA              15  12425.33  12313.79    Long          2025-04-03          2025-04-04
INDIGO                  10   5196.23   5365.55    Long          2025-04-09          2025-04-17
ORIENTCEM              200    354.44    355.22    Long          2025-04-09          2025-04-17
ASTERDM                100    495.08    498.30    Long          2025-04-09          2025-04-17
NH                      50   1715.50   1661.40    Long          2025-04-09          2025-04-09
LTF                    400    155.00    163.32    Long          2025-04-11          2025-04-17
JKCEMENT               249   5032.61   5025.52    Long          2025-04-11          2025-04-22
NTPC                   140    360.00    361.45    Long          2025-04-11          2025-04-22
INDIASHLTR              60    858.00    852.40    Long          2025-04-11          2025-04-17
GANECOS                100   1614.26   1675.05    Long          2025-04-17          2025-04-17
VBL                    200    561.00    554.40    Long          2025-04-17          2025-04-21
JSWINFRA               500    308.00    312.40    Long          2025-04-21          2025-04-21
BAJAJHFL              2000    131.86    131.25    Long          2025-04-21          2025-04-22
UPL                    300    668.00    674.30    Long          2025-04-21          2025-04-22
HEG                    400    486.93    482.85    Long          2025-04-22          2025-04-22
DCW                   3000     87.14     87.95    Long          2025-04-22          2025-04-22
BORORENEW              400    522.68    530.42    Long          2025-04-22          2025-04-22
ERIS                   115   1402.00   1400.15    Long          2025-04-22          2025-04-22
LLOYDSENT            10000     55.50     55.25    Long          2025-04-22          2025-04-22
TATAMOTORS           10000    642.10    640.45   Short          2025-04-23          2025-04-23
CEATLTD                 90   3070.60   3007.11    Long          2025-04-24          2025-04-25
DEEPAKFERT             500   1285.00   1289.00   Short          2025-04-24          2025-04-24
DEEPAKFERT            1000   1299.95   1309.00    Long          2025-04-24          2025-04-24
RHIM                  2500    465.01    467.66   Short          2025-04-24          2025-04-24
GODREJAGRO             800    788.87    794.63    Long          2025-04-24          2025-04-24
GODREJAGRO             300    795.00    767.20    Long          2025-04-24          2025-04-25
SHYAMMETL              250    911.01    894.40    Long          2025-04-25          2025-04-25
MEDPLUS                250    826.00    816.00    Long          2025-04-25          2025-04-25
JSWHL-BE                 5  26300.00  25550.00    Long          2025-04-25          2025-04-28
FORCEMOT                25   9175.54   9086.00    Long          2025-04-25          2025-04-25
MCLOUD                2500     73.40     71.30    Long          2025-04-25          2025-04-25
NYKAA                  725    195.27    195.70    Long          2025-04-29          2025-04-29
IIFL                   400    373.89    365.00    Long          2025-04-29          2025-04-29
GODREJCP               150   1271.73   1266.95    Long          2025-04-29          2025-04-29
SBILIFE                300   1778.40   1778.59    Long          2025-05-05          2025-05-05
SBILIFE                400   1777.16   1777.84   Short          2025-05-05          2025-05-05
TITAN                  300   3259.50   3265.00   Short          2025-05-06          2025-05-06
TITAN                  300   3253.58   3262.95   Short          2025-05-06          2025-05-06
PARAS                 1000   1366.81   1369.39   Short          2025-05-07          2025-05-07
HINDALCO              1500    628.38    629.10   Short          2025-05-08          2025-05-08
HINDALCO              2000    628.00    630.50   Short          2025-05-08          2025-05-08
SUNPHARMA             1500   1765.51   1767.90   Short          2025-05-08          2025-05-08
ONGC                  3000    234.06    234.37   Short          2025-05-09          2025-05-09
ONGC                  3500    234.10    234.35   Short          2025-05-09          2025-05-09
ADANIENT              1500   2237.00   2241.59   Short          2025-05-09          2025-05-09
ADANIENT              1000   2236.18   2241.89   Short          2025-05-09          2025-05-09
```