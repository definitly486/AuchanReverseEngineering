.class public Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;
.super Ljava/lang/Object;
.source "QrCode.java"

# interfaces
.implements Ljava/lang/Cloneable;


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;,
        Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;,
        Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;,
        Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;,
        Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Alignment;,
        Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$BlockInfo;
    }
.end annotation


# static fields
.field public static final LOCATION_BITS:[Ljava/util/List;

.field public static final VERSION_INFO:[Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;


# instance fields
.field public Hinv:Lcom/scanflow/datacapture/barinternal/georegression/struct/homography/Homography2D_F64;

.field public alignment:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

.field public bitsTransposed:Z

.field public bounds:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

.field public byteEncoding:Ljava/lang/String;

.field public corrected:[B

.field public error:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;

.field public failureCause:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;

.field public mask:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeMaskPattern;

.field public message:Ljava/lang/String;

.field public mode:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;

.field public ppCorner:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

.field public ppDown:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

.field public ppRight:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

.field public rawbits:[B

.field public threshCorner:D

.field public threshDown:D

.field public threshDownRight:D

.field public threshRight:D

.field public totalBitErrors:I

.field public version:I


# direct methods
.method static constructor <clinit>()V
    .locals 40

    const/16 v0, 0x29

    .line 51
    new-array v0, v0, [Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;

    sput-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->VERSION_INFO:[Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;

    const/16 v1, 0x29

    .line 54
    new-array v1, v1, [Ljava/util/ArrayList;

    sput-object v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->LOCATION_BITS:[Ljava/util/List;

    .line 127
    new-instance v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;

    const/4 v2, 0x0

    new-array v2, v2, [I

    const/16 v3, 0x1a

    invoke-direct {v1, v3, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;-><init>(I[I)V

    const/4 v2, 0x1

    aput-object v1, v0, v2

    .line 128
    sget-object v4, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;->L:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;

    const/16 v5, 0x13

    invoke-virtual {v1, v4, v3, v5, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 129
    aget-object v1, v0, v2

    sget-object v6, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;->M:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;

    const/16 v7, 0x10

    invoke-virtual {v1, v6, v3, v7, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 130
    aget-object v1, v0, v2

    sget-object v8, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;->Q:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;

    const/16 v9, 0xd

    invoke-virtual {v1, v8, v3, v9, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 131
    aget-object v1, v0, v2

    sget-object v10, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;->H:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;

    const/16 v11, 0x9

    invoke-virtual {v1, v10, v3, v11, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 133
    new-instance v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;

    const/4 v12, 0x6

    const/16 v13, 0x12

    filled-new-array {v12, v13}, [I

    move-result-object v14

    const/16 v15, 0x2c

    invoke-direct {v1, v15, v14}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;-><init>(I[I)V

    const/4 v14, 0x2

    aput-object v1, v0, v14

    const/16 v13, 0x22

    .line 134
    invoke-virtual {v1, v4, v15, v13, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 135
    aget-object v1, v0, v14

    const/16 v5, 0x1c

    invoke-virtual {v1, v6, v15, v5, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 136
    aget-object v1, v0, v14

    const/16 v5, 0x16

    invoke-virtual {v1, v8, v15, v5, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 137
    aget-object v1, v0, v14

    invoke-virtual {v1, v10, v15, v7, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 139
    new-instance v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;

    const/16 v7, 0x46

    filled-new-array {v12, v5}, [I

    move-result-object v13

    invoke-direct {v1, v7, v13}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;-><init>(I[I)V

    const/4 v7, 0x3

    aput-object v1, v0, v7

    const/16 v13, 0x46

    move/from16 v21, v7

    const/16 v7, 0x37

    .line 140
    invoke-virtual {v1, v4, v13, v7, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 141
    aget-object v1, v0, v21

    const/16 v7, 0x46

    invoke-virtual {v1, v6, v7, v15, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 142
    aget-object v1, v0, v21

    const/16 v7, 0x23

    const/16 v13, 0x11

    invoke-virtual {v1, v8, v7, v13, v14}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 143
    aget-object v1, v0, v21

    invoke-virtual {v1, v10, v7, v9, v14}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 145
    new-instance v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;

    const/16 v7, 0x64

    move/from16 v22, v13

    filled-new-array {v12, v3}, [I

    move-result-object v13

    invoke-direct {v1, v7, v13}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;-><init>(I[I)V

    const/4 v7, 0x4

    aput-object v1, v0, v7

    const/16 v13, 0x64

    const/16 v15, 0x50

    .line 146
    invoke-virtual {v1, v4, v13, v15, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 147
    aget-object v1, v0, v7

    const/16 v13, 0x32

    const/16 v15, 0x20

    invoke-virtual {v1, v6, v13, v15, v14}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 148
    aget-object v1, v0, v7

    const/16 v3, 0x18

    invoke-virtual {v1, v8, v13, v3, v14}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 149
    aget-object v1, v0, v7

    const/16 v13, 0x19

    invoke-virtual {v1, v10, v13, v11, v7}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 151
    new-instance v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;

    const/16 v13, 0x1e

    move/from16 v24, v11

    filled-new-array {v12, v13}, [I

    move-result-object v11

    const/16 v13, 0x86

    invoke-direct {v1, v13, v11}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;-><init>(I[I)V

    const/4 v11, 0x5

    aput-object v1, v0, v11

    move/from16 v26, v11

    const/16 v11, 0x6c

    .line 152
    invoke-virtual {v1, v4, v13, v11, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 153
    aget-object v1, v0, v26

    const/16 v11, 0x43

    const/16 v13, 0x2b

    invoke-virtual {v1, v6, v11, v13, v14}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 154
    aget-object v1, v0, v26

    const/16 v11, 0x21

    const/16 v2, 0xf

    invoke-virtual {v1, v8, v11, v2, v14}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 155
    aget-object v1, v0, v26

    const/16 v3, 0xb

    invoke-virtual {v1, v10, v11, v3, v14}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 157
    new-instance v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;

    move/from16 v27, v3

    const/16 v3, 0xac

    const/16 v11, 0x22

    filled-new-array {v12, v11}, [I

    move-result-object v9

    invoke-direct {v1, v3, v9}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;-><init>(I[I)V

    aput-object v1, v0, v12

    const/16 v3, 0x44

    const/16 v9, 0x56

    .line 158
    invoke-virtual {v1, v4, v9, v3, v14}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 159
    aget-object v1, v0, v12

    const/16 v3, 0x1b

    invoke-virtual {v1, v6, v13, v3, v7}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 160
    aget-object v1, v0, v12

    const/16 v3, 0x13

    invoke-virtual {v1, v8, v13, v3, v7}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 161
    aget-object v1, v0, v12

    invoke-virtual {v1, v10, v13, v2, v7}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 163
    new-instance v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;

    const/16 v3, 0x26

    filled-new-array {v12, v5, v3}, [I

    move-result-object v3

    const/16 v11, 0xc4

    invoke-direct {v1, v11, v3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;-><init>(I[I)V

    const/4 v3, 0x7

    aput-object v1, v0, v3

    const/16 v11, 0x62

    move/from16 v30, v3

    const/16 v3, 0x4e

    .line 164
    invoke-virtual {v1, v4, v11, v3, v14}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 165
    aget-object v1, v0, v30

    const/16 v3, 0x31

    const/16 v11, 0x1f

    invoke-virtual {v1, v6, v3, v11, v7}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 166
    aget-object v1, v0, v30

    const/16 v3, 0xe

    invoke-virtual {v1, v8, v15, v3, v14}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 167
    aget-object v1, v0, v30

    const/16 v11, 0x27

    const/16 v15, 0xd

    invoke-virtual {v1, v10, v11, v15, v7}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 169
    new-instance v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;

    const/16 v15, 0x2a

    const/16 v11, 0x18

    filled-new-array {v12, v11, v15}, [I

    move-result-object v5

    const/16 v11, 0xf2

    invoke-direct {v1, v11, v5}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;-><init>(I[I)V

    const/16 v5, 0x8

    aput-object v1, v0, v5

    const/16 v11, 0x79

    move/from16 v34, v5

    const/16 v5, 0x61

    .line 170
    invoke-virtual {v1, v4, v11, v5, v14}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 171
    aget-object v1, v0, v34

    const/16 v5, 0x3c

    const/16 v11, 0x26

    invoke-virtual {v1, v6, v5, v11, v14}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 172
    aget-object v1, v0, v34

    const/16 v5, 0x28

    const/16 v11, 0x12

    invoke-virtual {v1, v8, v5, v11, v7}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 173
    aget-object v1, v0, v34

    invoke-virtual {v1, v10, v5, v3, v7}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 175
    new-instance v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;

    const/16 v11, 0x2e

    const/16 v5, 0x1a

    filled-new-array {v12, v5, v11}, [I

    move-result-object v3

    const/16 v5, 0x124

    invoke-direct {v1, v5, v3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;-><init>(I[I)V

    aput-object v1, v0, v24

    const/16 v3, 0x92

    const/16 v5, 0x74

    .line 176
    invoke-virtual {v1, v4, v3, v5, v14}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 177
    aget-object v1, v0, v24

    const/16 v3, 0x3a

    const/16 v5, 0x24

    move/from16 v15, v21

    invoke-virtual {v1, v6, v3, v5, v15}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 178
    aget-object v1, v0, v24

    const/16 v15, 0x10

    invoke-virtual {v1, v8, v5, v15, v7}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 179
    aget-object v1, v0, v24

    const/16 v15, 0xc

    invoke-virtual {v1, v10, v5, v15, v7}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 181
    new-instance v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;

    const/16 v11, 0x15a

    const/16 v3, 0x1c

    const/16 v5, 0x32

    filled-new-array {v12, v3, v5}, [I

    move-result-object v15

    invoke-direct {v1, v11, v15}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;-><init>(I[I)V

    const/16 v3, 0xa

    aput-object v1, v0, v3

    const/16 v5, 0x44

    .line 182
    invoke-virtual {v1, v4, v9, v5, v14}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 183
    aget-object v1, v0, v3

    const/16 v5, 0x45

    invoke-virtual {v1, v6, v5, v13, v7}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 184
    aget-object v1, v0, v3

    const/16 v5, 0x13

    invoke-virtual {v1, v8, v13, v5, v12}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 185
    aget-object v1, v0, v3

    invoke-virtual {v1, v10, v13, v2, v12}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 187
    new-instance v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;

    const/16 v5, 0x36

    const/16 v11, 0x1e

    filled-new-array {v12, v11, v5}, [I

    move-result-object v15

    const/16 v11, 0x194

    invoke-direct {v1, v11, v15}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;-><init>(I[I)V

    aput-object v1, v0, v27

    const/16 v11, 0x65

    const/16 v15, 0x51

    .line 188
    invoke-virtual {v1, v4, v11, v15, v7}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 189
    aget-object v1, v0, v27

    const/16 v11, 0x50

    const/16 v9, 0x32

    const/4 v15, 0x1

    invoke-virtual {v1, v6, v11, v9, v15}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 190
    aget-object v1, v0, v27

    const/16 v11, 0x16

    invoke-virtual {v1, v8, v9, v11, v7}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 191
    aget-object v1, v0, v27

    const/16 v9, 0x24

    const/16 v11, 0xc

    const/4 v15, 0x3

    invoke-virtual {v1, v10, v9, v11, v15}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 193
    new-instance v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;

    const/16 v15, 0x1d2

    move/from16 v38, v2

    move/from16 v37, v11

    const/16 v3, 0x3a

    const/16 v11, 0x20

    filled-new-array {v12, v11, v3}, [I

    move-result-object v2

    invoke-direct {v1, v15, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;-><init>(I[I)V

    aput-object v1, v0, v37

    const/16 v2, 0x74

    const/16 v11, 0x5c

    .line 194
    invoke-virtual {v1, v4, v2, v11, v14}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 195
    aget-object v1, v0, v37

    invoke-virtual {v1, v6, v3, v9, v12}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 196
    aget-object v1, v0, v37

    const/16 v2, 0x14

    const/16 v3, 0x2e

    invoke-virtual {v1, v8, v3, v2, v7}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 197
    aget-object v1, v0, v37

    move/from16 v3, v30

    const/16 v9, 0xe

    const/16 v11, 0x2a

    invoke-virtual {v1, v10, v11, v9, v3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 199
    new-instance v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;

    const/16 v3, 0x3e

    const/16 v11, 0x22

    filled-new-array {v12, v11, v3}, [I

    move-result-object v3

    const/16 v9, 0x214

    invoke-direct {v1, v9, v3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;-><init>(I[I)V

    const/16 v29, 0xd

    aput-object v1, v0, v29

    const/16 v3, 0x85

    const/16 v9, 0x6b

    .line 200
    invoke-virtual {v1, v4, v3, v9, v7}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 201
    aget-object v1, v0, v29

    const/16 v3, 0x3b

    const/16 v9, 0x25

    move/from16 v11, v34

    invoke-virtual {v1, v6, v3, v9, v11}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 202
    aget-object v1, v0, v29

    const/16 v3, 0x2c

    invoke-virtual {v1, v8, v3, v2, v11}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 203
    aget-object v1, v0, v29

    move/from16 v9, v27

    const/16 v3, 0x21

    const/16 v11, 0xc

    invoke-virtual {v1, v10, v3, v9, v11}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 205
    new-instance v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;

    const/16 v3, 0x42

    const/16 v9, 0x1a

    const/16 v11, 0x2e

    filled-new-array {v12, v9, v11, v3}, [I

    move-result-object v3

    const/16 v9, 0x245

    invoke-direct {v1, v9, v3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;-><init>(I[I)V

    const/16 v35, 0xe

    aput-object v1, v0, v35

    const/16 v3, 0x91

    const/16 v9, 0x73

    const/4 v15, 0x3

    .line 206
    invoke-virtual {v1, v4, v3, v9, v15}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 207
    aget-object v1, v0, v35

    const/16 v3, 0x40

    const/16 v9, 0x28

    invoke-virtual {v1, v6, v3, v9, v7}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 208
    aget-object v1, v0, v35

    const/16 v3, 0x24

    const/16 v9, 0xb

    const/16 v15, 0x10

    invoke-virtual {v1, v8, v3, v15, v9}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 209
    aget-object v1, v0, v35

    const/16 v11, 0xc

    invoke-virtual {v1, v10, v3, v11, v9}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 211
    new-instance v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;

    const/16 v3, 0x30

    const/16 v9, 0x46

    const/16 v11, 0x1a

    filled-new-array {v12, v11, v3, v9}, [I

    move-result-object v3

    const/16 v9, 0x28f

    invoke-direct {v1, v9, v3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;-><init>(I[I)V

    aput-object v1, v0, v38

    const/16 v3, 0x6d

    const/16 v9, 0x57

    move/from16 v11, v26

    .line 212
    invoke-virtual {v1, v4, v3, v9, v11}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 213
    aget-object v1, v0, v38

    const/16 v3, 0x41

    const/16 v9, 0x29

    invoke-virtual {v1, v6, v3, v9, v11}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 214
    aget-object v1, v0, v38

    const/16 v3, 0x18

    invoke-virtual {v1, v8, v5, v3, v11}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 215
    aget-object v1, v0, v38

    const/16 v3, 0x24

    const/16 v9, 0xb

    const/16 v15, 0xc

    invoke-virtual {v1, v10, v3, v15, v9}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 217
    new-instance v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;

    const/16 v3, 0x4a

    move/from16 v39, v2

    const/16 v9, 0x1a

    const/16 v15, 0x32

    filled-new-array {v12, v9, v15, v3}, [I

    move-result-object v2

    const/16 v9, 0x2dd

    invoke-direct {v1, v9, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;-><init>(I[I)V

    const/16 v19, 0x10

    aput-object v1, v0, v19

    const/16 v2, 0x7a

    const/16 v9, 0x62

    .line 218
    invoke-virtual {v1, v4, v2, v9, v11}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 219
    aget-object v1, v0, v19

    const/16 v2, 0x49

    const/16 v9, 0x2d

    const/4 v11, 0x7

    invoke-virtual {v1, v6, v2, v9, v11}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 220
    aget-object v1, v0, v19

    move/from16 v11, v38

    const/16 v2, 0x13

    invoke-virtual {v1, v8, v13, v2, v11}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 221
    aget-object v1, v0, v19

    const/4 v15, 0x3

    invoke-virtual {v1, v10, v9, v11, v15}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 223
    new-instance v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;

    const/16 v2, 0x4e

    const/16 v11, 0x1e

    filled-new-array {v12, v11, v5, v2}, [I

    move-result-object v2

    const/16 v11, 0x32f

    invoke-direct {v1, v11, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;-><init>(I[I)V

    aput-object v1, v0, v22

    const/16 v2, 0x87

    const/16 v11, 0x6b

    const/4 v15, 0x1

    .line 224
    invoke-virtual {v1, v4, v2, v11, v15}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 225
    aget-object v1, v0, v22

    const/16 v2, 0xa

    const/16 v11, 0x2e

    invoke-virtual {v1, v6, v3, v11, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 226
    aget-object v1, v0, v22

    const/16 v2, 0x32

    const/16 v11, 0x16

    invoke-virtual {v1, v8, v2, v11, v15}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 227
    aget-object v1, v0, v22

    const/16 v2, 0xe

    const/16 v11, 0x2a

    invoke-virtual {v1, v10, v11, v2, v14}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 229
    new-instance v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;

    const/16 v2, 0x38

    const/16 v11, 0x52

    const/16 v15, 0x1e

    filled-new-array {v12, v15, v2, v11}, [I

    move-result-object v2

    const/16 v11, 0x385

    invoke-direct {v1, v11, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;-><init>(I[I)V

    const/16 v16, 0x12

    aput-object v1, v0, v16

    const/16 v2, 0x96

    const/16 v11, 0x78

    const/4 v15, 0x5

    .line 230
    invoke-virtual {v1, v4, v2, v11, v15}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 231
    aget-object v1, v0, v16

    const/16 v2, 0x45

    move/from16 v11, v24

    invoke-virtual {v1, v6, v2, v13, v11}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 232
    aget-object v1, v0, v16

    move/from16 v2, v22

    const/16 v11, 0x16

    const/16 v15, 0x32

    invoke-virtual {v1, v8, v15, v11, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 233
    aget-object v1, v0, v16

    const/16 v2, 0xe

    const/16 v11, 0x2a

    invoke-virtual {v1, v10, v11, v2, v14}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 235
    new-instance v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;

    const/16 v2, 0x3df

    const/16 v9, 0x3a

    const/16 v11, 0x1e

    const/16 v15, 0x56

    filled-new-array {v12, v11, v9, v15}, [I

    move-result-object v14

    invoke-direct {v1, v2, v14}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;-><init>(I[I)V

    const/16 v17, 0x13

    aput-object v1, v0, v17

    const/16 v2, 0x8d

    const/16 v9, 0x71

    const/4 v15, 0x3

    .line 236
    invoke-virtual {v1, v4, v2, v9, v15}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 237
    aget-object v1, v0, v17

    const/16 v2, 0x46

    const/16 v9, 0x2c

    invoke-virtual {v1, v6, v2, v9, v15}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 238
    aget-object v1, v0, v17

    const/16 v2, 0x15

    const/16 v9, 0x2f

    const/16 v11, 0x11

    invoke-virtual {v1, v8, v9, v2, v11}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 239
    aget-object v1, v0, v17

    const/16 v2, 0x27

    const/16 v11, 0x9

    const/16 v15, 0xd

    invoke-virtual {v1, v10, v2, v15, v11}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 241
    new-instance v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;

    const/16 v2, 0x3e

    const/16 v11, 0x5a

    const/16 v14, 0x22

    filled-new-array {v12, v14, v2, v11}, [I

    move-result-object v2

    const/16 v11, 0x43d

    invoke-direct {v1, v11, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;-><init>(I[I)V

    aput-object v1, v0, v39

    const/16 v2, 0x87

    const/16 v11, 0x6b

    const/4 v15, 0x3

    .line 242
    invoke-virtual {v1, v4, v2, v11, v15}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 243
    aget-object v1, v0, v39

    const/16 v2, 0x43

    const/16 v11, 0x29

    invoke-virtual {v1, v6, v2, v11, v15}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 244
    aget-object v1, v0, v39

    const/16 v2, 0xf

    const/16 v11, 0x18

    invoke-virtual {v1, v8, v5, v11, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 245
    aget-object v1, v0, v39

    invoke-virtual {v1, v10, v13, v2, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 247
    new-instance v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;

    const/16 v2, 0x48

    const/16 v11, 0x5e

    const/16 v14, 0x1c

    const/16 v15, 0x32

    filled-new-array {v12, v14, v15, v2, v11}, [I

    move-result-object v2

    const/16 v11, 0x484

    invoke-direct {v1, v11, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;-><init>(I[I)V

    const/16 v2, 0x15

    aput-object v1, v0, v2

    const/16 v2, 0x90

    const/16 v11, 0x74

    .line 248
    invoke-virtual {v1, v4, v2, v11, v7}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    const/16 v1, 0x15

    .line 249
    aget-object v1, v0, v1

    const/16 v2, 0x44

    const/16 v11, 0x11

    const/16 v14, 0x2a

    invoke-virtual {v1, v6, v2, v14, v11}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    const/16 v1, 0x15

    .line 250
    aget-object v1, v0, v1

    const/16 v2, 0x16

    const/16 v15, 0x32

    invoke-virtual {v1, v8, v15, v2, v11}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    const/16 v1, 0x15

    .line 251
    aget-object v1, v0, v1

    move/from16 v33, v2

    const/16 v2, 0x2e

    const/16 v11, 0x13

    const/16 v14, 0x10

    invoke-virtual {v1, v10, v2, v14, v11}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 253
    new-instance v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;

    const/16 v11, 0x62

    const/16 v14, 0x1a

    filled-new-array {v12, v14, v15, v3, v11}, [I

    move-result-object v11

    const/16 v14, 0x4ea

    invoke-direct {v1, v14, v11}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;-><init>(I[I)V

    aput-object v1, v0, v33

    const/16 v11, 0x8b

    const/16 v14, 0x6f

    const/4 v15, 0x2

    .line 254
    invoke-virtual {v1, v4, v11, v14, v15}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 255
    aget-object v1, v0, v33

    const/16 v11, 0x11

    invoke-virtual {v1, v6, v3, v2, v11}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 256
    aget-object v1, v0, v33

    const/4 v2, 0x7

    const/16 v11, 0x18

    invoke-virtual {v1, v8, v5, v11, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 257
    aget-object v1, v0, v33

    const/16 v2, 0x25

    const/16 v11, 0x22

    const/16 v15, 0xd

    invoke-virtual {v1, v10, v2, v15, v11}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 259
    new-instance v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;

    const/16 v2, 0x4e

    const/16 v11, 0x66

    const/16 v15, 0x1e

    filled-new-array {v12, v15, v5, v2, v11}, [I

    move-result-object v2

    const/16 v11, 0x554

    invoke-direct {v1, v11, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;-><init>(I[I)V

    const/16 v2, 0x17

    aput-object v1, v0, v2

    const/16 v11, 0x97

    const/16 v14, 0x79

    .line 260
    invoke-virtual {v1, v4, v11, v14, v7}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 261
    aget-object v1, v0, v2

    const/16 v11, 0x4b

    invoke-virtual {v1, v6, v11, v9, v7}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 262
    aget-object v1, v0, v2

    const/16 v11, 0x18

    const/16 v14, 0xb

    invoke-virtual {v1, v8, v5, v11, v14}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 263
    aget-object v1, v0, v2

    const/16 v13, 0x2d

    const/16 v14, 0xf

    const/16 v15, 0x10

    invoke-virtual {v1, v10, v13, v14, v15}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 266
    new-instance v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;

    const/16 v13, 0x50

    const/16 v14, 0x6a

    const/16 v15, 0x1c

    filled-new-array {v12, v15, v5, v13, v14}, [I

    move-result-object v13

    const/16 v14, 0x5c2

    invoke-direct {v1, v14, v13}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;-><init>(I[I)V

    aput-object v1, v0, v11

    const/16 v13, 0x93

    const/16 v14, 0x75

    .line 267
    invoke-virtual {v1, v4, v13, v14, v12}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 268
    aget-object v1, v0, v11

    const/16 v13, 0x49

    const/16 v14, 0x2d

    invoke-virtual {v1, v6, v13, v14, v12}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 269
    aget-object v1, v0, v11

    const/16 v14, 0xb

    invoke-virtual {v1, v8, v5, v11, v14}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 270
    aget-object v1, v0, v11

    const/16 v11, 0x1e

    const/16 v13, 0x2e

    const/16 v15, 0x10

    invoke-virtual {v1, v10, v13, v15, v11}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 272
    new-instance v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;

    const/16 v11, 0x54

    const/16 v13, 0x6e

    const/16 v14, 0x20

    const/16 v15, 0x3a

    filled-new-array {v12, v14, v15, v11, v13}, [I

    move-result-object v11

    const/16 v13, 0x634

    invoke-direct {v1, v13, v11}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;-><init>(I[I)V

    const/16 v11, 0x19

    aput-object v1, v0, v11

    const/16 v11, 0x84

    const/16 v13, 0x6a

    const/16 v14, 0x8

    .line 273
    invoke-virtual {v1, v4, v11, v13, v14}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    const/16 v1, 0x19

    .line 274
    aget-object v1, v0, v1

    const/16 v11, 0x4b

    invoke-virtual {v1, v6, v11, v9, v14}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    const/16 v1, 0x19

    .line 275
    aget-object v1, v0, v1

    const/16 v11, 0x18

    const/4 v13, 0x7

    invoke-virtual {v1, v8, v5, v11, v13}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    const/16 v1, 0x19

    .line 276
    aget-object v1, v0, v1

    const/16 v11, 0x16

    const/16 v13, 0x2d

    const/16 v14, 0xf

    invoke-virtual {v1, v10, v13, v14, v11}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 278
    new-instance v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;

    const/16 v11, 0x72

    const/16 v13, 0x56

    const/16 v14, 0x3a

    const/16 v15, 0x1e

    filled-new-array {v12, v15, v14, v13, v11}, [I

    move-result-object v11

    const/16 v13, 0x6aa

    invoke-direct {v1, v13, v11}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;-><init>(I[I)V

    const/16 v23, 0x1a

    aput-object v1, v0, v23

    const/16 v11, 0x8e

    const/16 v13, 0x72

    const/16 v14, 0xa

    .line 279
    invoke-virtual {v1, v4, v11, v13, v14}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 280
    aget-object v1, v0, v23

    const/16 v11, 0x13

    const/16 v13, 0x2e

    invoke-virtual {v1, v6, v3, v13, v11}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 281
    aget-object v1, v0, v23

    const/16 v11, 0x16

    const/16 v14, 0x1c

    const/16 v15, 0x32

    invoke-virtual {v1, v8, v15, v11, v14}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 282
    aget-object v1, v0, v23

    const/16 v11, 0x21

    const/16 v15, 0x10

    invoke-virtual {v1, v10, v13, v15, v11}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 284
    new-instance v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;

    const/16 v11, 0x5a

    const/16 v13, 0x76

    const/16 v14, 0x3e

    const/16 v15, 0x22

    filled-new-array {v12, v15, v14, v11, v13}, [I

    move-result-object v11

    const/16 v13, 0x724

    invoke-direct {v1, v13, v11}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;-><init>(I[I)V

    const/16 v11, 0x1b

    aput-object v1, v0, v11

    const/16 v11, 0x98

    const/16 v13, 0x7a

    const/16 v14, 0x8

    .line 285
    invoke-virtual {v1, v4, v11, v13, v14}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    const/16 v1, 0x1b

    .line 286
    aget-object v1, v0, v1

    const/16 v11, 0x49

    const/16 v13, 0x16

    const/16 v15, 0x2d

    invoke-virtual {v1, v6, v11, v15, v13}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    const/16 v1, 0x1b

    .line 287
    aget-object v1, v0, v1

    const/16 v11, 0x35

    invoke-virtual {v1, v8, v11, v2, v14}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    const/16 v1, 0x1b

    .line 288
    aget-object v1, v0, v1

    const/16 v11, 0xc

    const/16 v14, 0xf

    invoke-virtual {v1, v10, v15, v14, v11}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 290
    new-instance v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;

    new-array v11, v12, [I

    fill-array-data v11, :array_0

    const/16 v13, 0x781

    invoke-direct {v1, v13, v11}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;-><init>(I[I)V

    const/16 v18, 0x1c

    aput-object v1, v0, v18

    const/16 v11, 0x93

    const/16 v13, 0x75

    const/4 v15, 0x3

    .line 291
    invoke-virtual {v1, v4, v11, v13, v15}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 292
    aget-object v1, v0, v18

    const/16 v11, 0x49

    const/16 v13, 0x2d

    invoke-virtual {v1, v6, v11, v13, v15}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 293
    aget-object v1, v0, v18

    const/16 v11, 0x18

    invoke-virtual {v1, v8, v5, v11, v7}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 294
    aget-object v1, v0, v18

    const/16 v11, 0xb

    const/16 v14, 0xf

    invoke-virtual {v1, v10, v13, v14, v11}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 296
    new-instance v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;

    new-array v11, v12, [I

    fill-array-data v11, :array_1

    const/16 v13, 0x803

    invoke-direct {v1, v13, v11}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;-><init>(I[I)V

    const/16 v11, 0x1d

    aput-object v1, v0, v11

    const/16 v11, 0x92

    const/16 v13, 0x74

    const/4 v14, 0x7

    .line 297
    invoke-virtual {v1, v4, v11, v13, v14}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    const/16 v1, 0x1d

    .line 298
    aget-object v1, v0, v1

    const/16 v11, 0x49

    const/16 v13, 0x15

    const/16 v14, 0x2d

    invoke-virtual {v1, v6, v11, v14, v13}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    const/16 v1, 0x1d

    .line 299
    aget-object v1, v0, v1

    const/16 v11, 0x35

    const/4 v15, 0x1

    invoke-virtual {v1, v8, v11, v2, v15}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    const/16 v1, 0x1d

    .line 300
    aget-object v1, v0, v1

    const/16 v11, 0x13

    const/16 v13, 0xf

    invoke-virtual {v1, v10, v14, v13, v11}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 302
    new-instance v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;

    new-array v11, v12, [I

    fill-array-data v11, :array_2

    const/16 v13, 0x889

    invoke-direct {v1, v13, v11}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;-><init>(I[I)V

    const/16 v25, 0x1e

    aput-object v1, v0, v25

    const/16 v11, 0x91

    const/16 v13, 0x73

    const/4 v14, 0x5

    .line 303
    invoke-virtual {v1, v4, v11, v13, v14}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 304
    aget-object v1, v0, v25

    const/16 v11, 0x4b

    const/16 v13, 0x13

    invoke-virtual {v1, v6, v11, v9, v13}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 305
    aget-object v1, v0, v25

    const/16 v11, 0x18

    const/16 v14, 0xf

    invoke-virtual {v1, v8, v5, v11, v14}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 306
    aget-object v1, v0, v25

    const/16 v13, 0x2d

    invoke-virtual {v1, v10, v13, v14, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 308
    new-instance v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;

    new-array v11, v12, [I

    fill-array-data v11, :array_3

    const/16 v13, 0x913

    invoke-direct {v1, v13, v11}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;-><init>(I[I)V

    const/16 v11, 0x1f

    aput-object v1, v0, v11

    const/16 v11, 0x91

    const/16 v13, 0x73

    const/16 v14, 0xd

    .line 309
    invoke-virtual {v1, v4, v11, v13, v14}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    const/16 v1, 0x1f

    .line 310
    aget-object v1, v0, v1

    const/4 v11, 0x2

    const/16 v13, 0x2e

    invoke-virtual {v1, v6, v3, v13, v11}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    const/16 v1, 0x1f

    .line 311
    aget-object v1, v0, v1

    const/16 v11, 0x18

    const/16 v14, 0x2a

    invoke-virtual {v1, v8, v5, v11, v14}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    const/16 v1, 0x1f

    .line 312
    aget-object v1, v0, v1

    const/16 v13, 0x2d

    const/16 v14, 0xf

    invoke-virtual {v1, v10, v13, v14, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 314
    new-instance v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;

    new-array v2, v12, [I

    fill-array-data v2, :array_4

    const/16 v11, 0x9a1

    invoke-direct {v1, v11, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;-><init>(I[I)V

    const/16 v31, 0x20

    aput-object v1, v0, v31

    const/16 v2, 0x91

    const/16 v11, 0x73

    const/16 v13, 0x11

    .line 315
    invoke-virtual {v1, v4, v2, v11, v13}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 316
    aget-object v1, v0, v31

    const/16 v2, 0xa

    const/16 v13, 0x2e

    invoke-virtual {v1, v6, v3, v13, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 317
    aget-object v1, v0, v31

    const/16 v11, 0x18

    invoke-virtual {v1, v8, v5, v11, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 318
    aget-object v1, v0, v31

    const/16 v11, 0x13

    const/16 v13, 0x2d

    const/16 v14, 0xf

    invoke-virtual {v1, v10, v13, v14, v11}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 320
    new-instance v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;

    new-array v2, v12, [I

    fill-array-data v2, :array_5

    const/16 v11, 0xa33

    invoke-direct {v1, v11, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;-><init>(I[I)V

    const/16 v28, 0x21

    aput-object v1, v0, v28

    const/16 v2, 0x91

    const/16 v11, 0x73

    const/16 v13, 0x11

    .line 321
    invoke-virtual {v1, v4, v2, v11, v13}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 322
    aget-object v1, v0, v28

    const/16 v2, 0xe

    const/16 v13, 0x2e

    invoke-virtual {v1, v6, v3, v13, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 323
    aget-object v1, v0, v28

    const/16 v2, 0x1d

    const/16 v11, 0x18

    invoke-virtual {v1, v8, v5, v11, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 324
    aget-object v1, v0, v28

    const/16 v11, 0xb

    const/16 v13, 0x2d

    const/16 v14, 0xf

    invoke-virtual {v1, v10, v13, v14, v11}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 326
    new-instance v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;

    new-array v2, v12, [I

    fill-array-data v2, :array_6

    const/16 v11, 0xac9

    invoke-direct {v1, v11, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;-><init>(I[I)V

    const/16 v20, 0x22

    aput-object v1, v0, v20

    const/16 v2, 0x91

    const/16 v11, 0x73

    const/16 v14, 0xd

    .line 327
    invoke-virtual {v1, v4, v2, v11, v14}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 328
    aget-object v1, v0, v20

    const/16 v2, 0xe

    const/16 v13, 0x2e

    invoke-virtual {v1, v6, v3, v13, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 329
    aget-object v1, v0, v20

    const/16 v2, 0x2c

    const/16 v11, 0x18

    invoke-virtual {v1, v8, v5, v11, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 330
    aget-object v1, v0, v20

    const/16 v2, 0x3b

    const/16 v14, 0x10

    invoke-virtual {v1, v10, v13, v14, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 332
    new-instance v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;

    const/4 v2, 0x7

    new-array v11, v2, [I

    fill-array-data v11, :array_7

    const/16 v2, 0xb3c

    invoke-direct {v1, v2, v11}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;-><init>(I[I)V

    const/16 v2, 0x23

    aput-object v1, v0, v2

    const/16 v2, 0x97

    const/16 v11, 0x79

    const/16 v13, 0xc

    .line 333
    invoke-virtual {v1, v4, v2, v11, v13}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    const/16 v1, 0x23

    .line 334
    aget-object v1, v0, v1

    const/16 v2, 0x4b

    invoke-virtual {v1, v6, v2, v9, v13}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    const/16 v1, 0x23

    .line 335
    aget-object v1, v0, v1

    const/16 v2, 0x27

    const/16 v11, 0x18

    invoke-virtual {v1, v8, v5, v11, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    const/16 v1, 0x23

    .line 336
    aget-object v1, v0, v1

    const/16 v11, 0x16

    const/16 v13, 0x2d

    const/16 v14, 0xf

    invoke-virtual {v1, v10, v13, v14, v11}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 338
    new-instance v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;

    const/4 v2, 0x7

    new-array v11, v2, [I

    fill-array-data v11, :array_8

    const/16 v2, 0xbda

    invoke-direct {v1, v2, v11}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;-><init>(I[I)V

    const/16 v36, 0x24

    aput-object v1, v0, v36

    const/16 v2, 0x97

    const/16 v11, 0x79

    .line 339
    invoke-virtual {v1, v4, v2, v11, v12}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 340
    aget-object v1, v0, v36

    const/16 v2, 0x4b

    invoke-virtual {v1, v6, v2, v9, v12}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 341
    aget-object v1, v0, v36

    const/16 v11, 0x18

    const/16 v13, 0x2e

    invoke-virtual {v1, v8, v5, v11, v13}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 342
    aget-object v1, v0, v36

    const/4 v11, 0x2

    const/16 v13, 0x2d

    const/16 v14, 0xf

    invoke-virtual {v1, v10, v13, v14, v11}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 344
    new-instance v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;

    const/4 v2, 0x7

    new-array v11, v2, [I

    fill-array-data v11, :array_9

    const/16 v2, 0xc7c

    invoke-direct {v1, v2, v11}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;-><init>(I[I)V

    const/16 v2, 0x25

    aput-object v1, v0, v2

    const/16 v2, 0x98

    const/16 v11, 0x7a

    const/16 v13, 0x11

    .line 345
    invoke-virtual {v1, v4, v2, v11, v13}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    const/16 v1, 0x25

    .line 346
    aget-object v1, v0, v1

    const/16 v2, 0x1d

    const/16 v13, 0x2e

    invoke-virtual {v1, v6, v3, v13, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    const/16 v1, 0x25

    .line 347
    aget-object v1, v0, v1

    const/16 v2, 0x31

    const/16 v11, 0x18

    invoke-virtual {v1, v8, v5, v11, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    const/16 v1, 0x25

    .line 348
    aget-object v1, v0, v1

    const/16 v13, 0x2d

    const/16 v14, 0xf

    invoke-virtual {v1, v10, v13, v14, v11}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 350
    new-instance v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;

    const/4 v2, 0x7

    new-array v11, v2, [I

    fill-array-data v11, :array_a

    const/16 v2, 0xd22

    invoke-direct {v1, v2, v11}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;-><init>(I[I)V

    const/16 v2, 0x26

    aput-object v1, v0, v2

    const/16 v2, 0x98

    const/16 v11, 0x7a

    .line 351
    invoke-virtual {v1, v4, v2, v11, v7}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    const/16 v1, 0x26

    .line 352
    aget-object v1, v0, v1

    const/16 v13, 0x2e

    const/16 v14, 0xd

    invoke-virtual {v1, v6, v3, v13, v14}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    const/16 v1, 0x26

    .line 353
    aget-object v1, v0, v1

    const/16 v2, 0x30

    const/16 v11, 0x18

    invoke-virtual {v1, v8, v5, v11, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    const/16 v1, 0x26

    .line 354
    aget-object v1, v0, v1

    const/16 v11, 0x2a

    const/16 v13, 0x2d

    const/16 v14, 0xf

    invoke-virtual {v1, v10, v13, v14, v11}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 356
    new-instance v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;

    const/4 v2, 0x7

    new-array v3, v2, [I

    fill-array-data v3, :array_b

    const/16 v2, 0xdcc

    invoke-direct {v1, v2, v3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;-><init>(I[I)V

    const/16 v32, 0x27

    aput-object v1, v0, v32

    const/16 v2, 0x93

    const/16 v3, 0x75

    move/from16 v7, v39

    .line 357
    invoke-virtual {v1, v4, v2, v3, v7}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 358
    aget-object v1, v0, v32

    const/16 v2, 0x4b

    const/16 v3, 0x28

    invoke-virtual {v1, v6, v2, v9, v3}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 359
    aget-object v1, v0, v32

    const/16 v2, 0x2b

    const/16 v11, 0x18

    invoke-virtual {v1, v8, v5, v11, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 360
    aget-object v1, v0, v32

    const/16 v2, 0xa

    const/16 v13, 0x2d

    const/16 v14, 0xf

    invoke-virtual {v1, v10, v13, v14, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 362
    new-instance v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;

    const/4 v2, 0x7

    new-array v2, v2, [I

    fill-array-data v2, :array_c

    const/16 v7, 0xe7a

    invoke-direct {v1, v7, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;-><init>(I[I)V

    aput-object v1, v0, v3

    const/16 v2, 0x94

    const/16 v7, 0x76

    const/16 v11, 0x13

    .line 363
    invoke-virtual {v1, v4, v2, v7, v11}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 364
    aget-object v1, v0, v3

    const/16 v2, 0x4b

    const/16 v11, 0x12

    invoke-virtual {v1, v6, v2, v9, v11}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 365
    aget-object v1, v0, v3

    const/16 v2, 0x18

    const/16 v11, 0x22

    invoke-virtual {v1, v8, v5, v2, v11}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    .line 366
    aget-object v0, v0, v3

    const/16 v7, 0x14

    const/16 v13, 0x2d

    const/16 v14, 0xf

    invoke-virtual {v0, v10, v13, v14, v7}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$VersionInfo;->add(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;III)V

    move v2, v15

    :goto_0
    if-gt v2, v3, :cond_0

    .line 369
    sget-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->LOCATION_BITS:[Ljava/util/List;

    invoke-static {v2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeCodeWordLocations;->qrcode(I)Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeCodeWordLocations;

    move-result-object v1

    iget-object v1, v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeCodeWordLocations;->bits:Ljava/util/List;

    aput-object v1, v0, v2

    add-int/lit8 v2, v2, 0x1

    goto :goto_0

    :cond_0
    return-void

    :array_0
    .array-data 4
        0x6
        0x1a
        0x32
        0x4a
        0x62
        0x7a
    .end array-data

    :array_1
    .array-data 4
        0x6
        0x1e
        0x36
        0x4e
        0x66
        0x7e
    .end array-data

    :array_2
    .array-data 4
        0x6
        0x1a
        0x34
        0x4e
        0x68
        0x82
    .end array-data

    :array_3
    .array-data 4
        0x6
        0x1e
        0x38
        0x52
        0x6c
        0x86
    .end array-data

    :array_4
    .array-data 4
        0x6
        0x22
        0x3c
        0x56
        0x70
        0x8a
    .end array-data

    :array_5
    .array-data 4
        0x6
        0x1e
        0x3a
        0x56
        0x72
        0x8e
    .end array-data

    :array_6
    .array-data 4
        0x6
        0x22
        0x3e
        0x5a
        0x76
        0x92
    .end array-data

    :array_7
    .array-data 4
        0x6
        0x1e
        0x36
        0x4e
        0x66
        0x7e
        0x96
    .end array-data

    :array_8
    .array-data 4
        0x6
        0x18
        0x32
        0x4c
        0x66
        0x80
        0x9a
    .end array-data

    :array_9
    .array-data 4
        0x6
        0x1c
        0x36
        0x50
        0x6a
        0x84
        0x9e
    .end array-data

    :array_a
    .array-data 4
        0x6
        0x20
        0x3a
        0x54
        0x6e
        0x88
        0xa2
    .end array-data

    :array_b
    .array-data 4
        0x6
        0x1a
        0x36
        0x52
        0x6e
        0x8a
        0xa6
    .end array-data

    :array_c
    .array-data 4
        0x6
        0x1e
        0x3a
        0x56
        0x72
        0x8e
        0xaa
    .end array-data
.end method

.method public constructor <init>()V
    .locals 3

    .line 373
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 61
    new-instance v0, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    const/4 v1, 0x4

    invoke-direct {v0, v1}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;-><init>(I)V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->ppRight:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    .line 62
    new-instance v0, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    invoke-direct {v0, v1}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;-><init>(I)V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->ppCorner:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    .line 63
    new-instance v0, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    invoke-direct {v0, v1}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;-><init>(I)V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->ppDown:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    .line 81
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    new-instance v2, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$$ExternalSyntheticLambda0;

    invoke-direct {v2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$$ExternalSyntheticLambda0;-><init>()V

    invoke-direct {v0, v2}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;-><init>(Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/Factory;)V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->alignment:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    .line 84
    sget-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;->UNKNOWN:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->mode:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;

    .line 91
    const-string v0, ""

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->byteEncoding:Ljava/lang/String;

    .line 100
    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->message:Ljava/lang/String;

    .line 103
    sget-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;->NONE:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->failureCause:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;

    .line 111
    new-instance v0, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    invoke-direct {v0, v1}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;-><init>(I)V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->bounds:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    .line 114
    new-instance v0, Lcom/scanflow/datacapture/barinternal/georegression/struct/homography/Homography2D_F64;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/georegression/struct/homography/Homography2D_F64;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->Hinv:Lcom/scanflow/datacapture/barinternal/georegression/struct/homography/Homography2D_F64;

    .line 374
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->reset()V

    return-void
.end method

.method public static totalModules(I)I
    .locals 0

    .line 386
    mul-int/lit8 p0, p0, 0x4

    add-int/lit8 p0, p0, 0x11

    return p0
.end method


# virtual methods
.method public clone()Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;
    .locals 1

    .line 417
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;-><init>()V

    invoke-virtual {v0, p0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->setTo(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;)Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;

    move-result-object v0

    return-object v0
.end method

.method public bridge synthetic clone()Ljava/lang/Object;
    .locals 1

    .line 40
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->clone()Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;

    move-result-object v0

    return-object v0
.end method

.method public getNumberOfModules()I
    .locals 1

    .line 378
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->version:I

    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->totalModules(I)I

    move-result v0

    return v0
.end method

.method public reset()V
    .locals 5

    const/4 v0, 0x0

    move v1, v0

    :goto_0
    const/4 v2, 0x4

    const-wide/16 v3, 0x0

    if-ge v1, v2, :cond_0

    .line 395
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->ppCorner:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    invoke-virtual {v2, v1}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->get(I)Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    move-result-object v2

    invoke-virtual {v2, v3, v4, v3, v4}, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->setTo(DD)Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;

    .line 396
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->ppDown:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    invoke-virtual {v2, v1}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->get(I)Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    move-result-object v2

    invoke-virtual {v2, v3, v4, v3, v4}, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->setTo(DD)Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;

    .line 397
    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->ppRight:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    invoke-virtual {v2, v1}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->get(I)Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    move-result-object v2

    invoke-virtual {v2, v3, v4, v3, v4}, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;->setTo(DD)Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F64;

    add-int/lit8 v1, v1, 0x1

    goto :goto_0

    .line 399
    :cond_0
    iput-wide v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->threshCorner:D

    .line 400
    iput-wide v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->threshDown:D

    .line 401
    iput-wide v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->threshRight:D

    const/4 v1, -0x1

    .line 402
    iput v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->version:I

    .line 403
    sget-object v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;->L:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;

    iput-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->error:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;

    .line 404
    sget-object v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeMaskPattern;->M111:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeMaskPattern;

    iput-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->mask:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeMaskPattern;

    .line 405
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->alignment:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;->reset()Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    .line 406
    sget-object v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;->UNKNOWN:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;

    iput-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->mode:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;

    .line 407
    sget-object v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;->NONE:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;

    iput-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->failureCause:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;

    .line 408
    const-string v1, ""

    iput-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->byteEncoding:Ljava/lang/String;

    const/4 v1, 0x0

    .line 409
    iput-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->rawbits:[B

    .line 410
    iput-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->corrected:[B

    .line 411
    iput-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->message:Ljava/lang/String;

    .line 412
    iput-boolean v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->bitsTransposed:Z

    .line 413
    iput v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->totalBitErrors:I

    return-void
.end method

.method public setTo(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;)Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;
    .locals 3

    .line 427
    iget v0, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->version:I

    iput v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->version:I

    .line 428
    iget-object v0, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->error:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->error:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$ErrorLevel;

    .line 429
    iget-object v0, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->mask:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeMaskPattern;

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->mask:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCodeMaskPattern;

    .line 430
    iget-object v0, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->mode:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->mode:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Mode;

    .line 431
    iget-object v0, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->rawbits:[B

    const/4 v1, 0x0

    if-nez v0, :cond_0

    move-object v0, v1

    goto :goto_0

    :cond_0
    invoke-virtual {v0}, [B->clone()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, [B

    :goto_0
    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->rawbits:[B

    .line 432
    iget-object v0, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->corrected:[B

    if-nez v0, :cond_1

    goto :goto_1

    :cond_1
    invoke-virtual {v0}, [B->clone()Ljava/lang/Object;

    move-result-object v0

    move-object v1, v0

    check-cast v1, [B

    :goto_1
    iput-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->corrected:[B

    .line 433
    iget-object v0, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->message:Ljava/lang/String;

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->message:Ljava/lang/String;

    .line 434
    iget-wide v0, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->threshCorner:D

    iput-wide v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->threshCorner:D

    .line 435
    iget-wide v0, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->threshDown:D

    iput-wide v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->threshDown:D

    .line 436
    iget-wide v0, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->threshRight:D

    iput-wide v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->threshRight:D

    .line 437
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->ppCorner:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    iget-object v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->ppCorner:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    invoke-virtual {v0, v1}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->setTo(Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;)Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    .line 438
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->ppDown:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    iget-object v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->ppDown:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    invoke-virtual {v0, v1}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->setTo(Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;)Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    .line 439
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->ppRight:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    iget-object v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->ppRight:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    invoke-virtual {v0, v1}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->setTo(Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;)Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    .line 440
    iget-object v0, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->failureCause:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->failureCause:Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Failure;

    .line 441
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->bounds:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    iget-object v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->bounds:Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    invoke-virtual {v0, v1}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->setTo(Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;)Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;

    .line 442
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->alignment:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;->reset()Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    const/4 v0, 0x0

    .line 443
    :goto_2
    iget-object v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->alignment:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    iget v1, v1, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastAccess;->size:I

    if-ge v0, v1, :cond_2

    .line 444
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->alignment:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;->grow()Ljava/lang/Object;

    move-result-object v1

    check-cast v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Alignment;

    iget-object v2, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->alignment:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    invoke-virtual {v2, v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastAccess;->get(I)Ljava/lang/Object;

    move-result-object v2

    check-cast v2, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Alignment;

    invoke-virtual {v1, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Alignment;->set(Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode$Alignment;)V

    add-int/lit8 v0, v0, 0x1

    goto :goto_2

    .line 446
    :cond_2
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->Hinv:Lcom/scanflow/datacapture/barinternal/georegression/struct/homography/Homography2D_F64;

    iget-object v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->Hinv:Lcom/scanflow/datacapture/barinternal/georegression/struct/homography/Homography2D_F64;

    invoke-virtual {v0, v1}, Lcom/scanflow/datacapture/barinternal/georegression/struct/homography/Homography2D_F64;->setTo(Lcom/scanflow/datacapture/barinternal/georegression/struct/homography/Homography2D_F64;)Lcom/scanflow/datacapture/barinternal/georegression/struct/homography/Homography2D_F64;

    .line 447
    iget-boolean v0, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->bitsTransposed:Z

    iput-boolean v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->bitsTransposed:Z

    .line 448
    iget p1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->totalBitErrors:I

    iput p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/fiducial/qrcode/QrCode;->totalBitErrors:I

    return-object p0
.end method
