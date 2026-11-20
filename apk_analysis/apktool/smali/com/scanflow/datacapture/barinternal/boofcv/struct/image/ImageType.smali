.class public Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;
.super Ljava/lang/Object;
.source "ImageType.java"

# interfaces
.implements Ljava/io/Serializable;


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType$Family;
    }
.end annotation


# static fields
.field public static final IL_F32:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

.field public static final IL_F64:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

.field public static final IL_S16:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

.field public static final IL_S32:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

.field public static final IL_S64:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

.field public static final IL_S8:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

.field public static final IL_U16:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

.field public static final IL_U8:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

.field public static final PL_F32:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

.field public static final PL_F64:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

.field public static final PL_S16:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

.field public static final PL_S32:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

.field public static final PL_S64:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

.field public static final PL_S8:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

.field public static final PL_U16:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

.field public static final PL_U8:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

.field public static final SB_F32:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

.field public static final SB_F64:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

.field public static final SB_S16:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

.field public static final SB_S32:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

.field public static final SB_S64:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

.field public static final SB_S8:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

.field public static final SB_U16:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

.field public static final SB_U8:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;


# instance fields
.field dataType:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;

.field family:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType$Family;

.field public numBands:I


# direct methods
.method static constructor <clinit>()V
    .locals 10

    .line 32
    const-class v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;->single(Ljava/lang/Class;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

    move-result-object v1

    sput-object v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;->SB_U8:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

    .line 33
    const-class v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS8;

    invoke-static {v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;->single(Ljava/lang/Class;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

    move-result-object v2

    sput-object v2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;->SB_S8:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

    .line 34
    const-class v2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;

    invoke-static {v2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;->single(Ljava/lang/Class;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

    move-result-object v3

    sput-object v3, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;->SB_U16:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

    .line 35
    const-class v3, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS16;

    invoke-static {v3}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;->single(Ljava/lang/Class;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

    move-result-object v4

    sput-object v4, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;->SB_S16:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

    .line 36
    const-class v4, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS32;

    invoke-static {v4}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;->single(Ljava/lang/Class;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

    move-result-object v5

    sput-object v5, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;->SB_S32:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

    .line 37
    const-class v5, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS64;

    invoke-static {v5}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;->single(Ljava/lang/Class;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

    move-result-object v6

    sput-object v6, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;->SB_S64:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

    .line 38
    const-class v6, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    invoke-static {v6}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;->single(Ljava/lang/Class;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

    move-result-object v7

    sput-object v7, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;->SB_F32:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

    .line 39
    const-class v7, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;

    invoke-static {v7}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;->single(Ljava/lang/Class;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

    move-result-object v8

    sput-object v8, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;->SB_F64:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

    .line 40
    const-class v8, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedU8;

    const/4 v9, 0x0

    invoke-static {v9, v8}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;->il(ILjava/lang/Class;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

    move-result-object v8

    sput-object v8, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;->IL_U8:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

    .line 41
    const-class v8, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedS8;

    invoke-static {v9, v8}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;->il(ILjava/lang/Class;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

    move-result-object v8

    sput-object v8, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;->IL_S8:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

    .line 42
    const-class v8, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedU16;

    invoke-static {v9, v8}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;->il(ILjava/lang/Class;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

    move-result-object v8

    sput-object v8, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;->IL_U16:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

    .line 43
    const-class v8, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedS16;

    invoke-static {v9, v8}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;->il(ILjava/lang/Class;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

    move-result-object v8

    sput-object v8, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;->IL_S16:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

    .line 44
    const-class v8, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedS32;

    invoke-static {v9, v8}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;->il(ILjava/lang/Class;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

    move-result-object v8

    sput-object v8, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;->IL_S32:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

    .line 45
    const-class v8, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedS64;

    invoke-static {v9, v8}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;->il(ILjava/lang/Class;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

    move-result-object v8

    sput-object v8, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;->IL_S64:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

    .line 46
    const-class v8, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedF32;

    invoke-static {v9, v8}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;->il(ILjava/lang/Class;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

    move-result-object v8

    sput-object v8, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;->IL_F32:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

    .line 47
    const-class v8, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedF64;

    invoke-static {v9, v8}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;->il(ILjava/lang/Class;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

    move-result-object v8

    sput-object v8, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;->IL_F64:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

    .line 48
    invoke-static {v9, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;->pl(ILjava/lang/Class;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

    move-result-object v0

    sput-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;->PL_U8:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

    .line 49
    invoke-static {v9, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;->pl(ILjava/lang/Class;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

    move-result-object v0

    sput-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;->PL_S8:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

    .line 50
    invoke-static {v9, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;->pl(ILjava/lang/Class;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

    move-result-object v0

    sput-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;->PL_U16:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

    .line 51
    invoke-static {v9, v3}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;->pl(ILjava/lang/Class;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

    move-result-object v0

    sput-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;->PL_S16:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

    .line 52
    invoke-static {v9, v4}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;->pl(ILjava/lang/Class;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

    move-result-object v0

    sput-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;->PL_S32:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

    .line 53
    invoke-static {v9, v5}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;->pl(ILjava/lang/Class;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

    move-result-object v0

    sput-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;->PL_S64:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

    .line 54
    invoke-static {v9, v6}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;->pl(ILjava/lang/Class;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

    move-result-object v0

    sput-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;->PL_F32:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

    .line 55
    invoke-static {v9, v7}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;->pl(ILjava/lang/Class;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

    move-result-object v0

    sput-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;->PL_F64:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

    return-void
.end method

.method public constructor <init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType$Family;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;I)V
    .locals 0

    .line 70
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 71
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;->family:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType$Family;

    .line 72
    iput-object p2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;->dataType:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;

    .line 73
    iput p3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;->numBands:I

    return-void
.end method

.method public static getImageClass(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType$Family;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;)Ljava/lang/Class;
    .locals 2

    .line 193
    sget-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType$1;->$SwitchMap$boofcv$struct$image$ImageType$Family:[I

    invoke-virtual {p0}, Ljava/lang/Enum;->ordinal()I

    move-result p0

    aget p0, v0, p0

    const/4 v0, 0x1

    const-string v1, "Support this image type thing"

    if-eq p0, v0, :cond_2

    const/4 v0, 0x2

    if-eq p0, v0, :cond_1

    const/4 v0, 0x3

    if-ne p0, v0, :cond_0

    goto :goto_0

    :cond_0
    new-instance p0, Ljava/lang/IncompatibleClassChangeError;

    invoke-direct {p0}, Ljava/lang/IncompatibleClassChangeError;-><init>()V

    throw p0

    .line 207
    :cond_1
    sget-object p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType$1;->$SwitchMap$boofcv$struct$image$ImageDataType:[I

    invoke-virtual {p1}, Ljava/lang/Enum;->ordinal()I

    move-result p1

    aget p0, p0, p1

    packed-switch p0, :pswitch_data_0

    .line 218
    new-instance p0, Ljava/lang/RuntimeException;

    invoke-direct {p0, v1}, Ljava/lang/RuntimeException;-><init>(Ljava/lang/String;)V

    throw p0

    .line 217
    :pswitch_0
    const-class p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedI16;

    return-object p0

    .line 216
    :pswitch_1
    const-class p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedI8;

    return-object p0

    .line 215
    :pswitch_2
    const-class p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedS64;

    return-object p0

    .line 214
    :pswitch_3
    const-class p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedS32;

    return-object p0

    .line 213
    :pswitch_4
    const-class p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedS16;

    return-object p0

    .line 212
    :pswitch_5
    const-class p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedU16;

    return-object p0

    .line 211
    :pswitch_6
    const-class p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedS8;

    return-object p0

    .line 210
    :pswitch_7
    const-class p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedU8;

    return-object p0

    .line 209
    :pswitch_8
    const-class p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedF64;

    return-object p0

    .line 208
    :pswitch_9
    const-class p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/InterleavedF32;

    return-object p0

    .line 194
    :cond_2
    :goto_0
    sget-object p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType$1;->$SwitchMap$boofcv$struct$image$ImageDataType:[I

    invoke-virtual {p1}, Ljava/lang/Enum;->ordinal()I

    move-result p1

    aget p0, p0, p1

    packed-switch p0, :pswitch_data_1

    .line 205
    new-instance p0, Ljava/lang/RuntimeException;

    invoke-direct {p0, v1}, Ljava/lang/RuntimeException;-><init>(Ljava/lang/String;)V

    throw p0

    .line 204
    :pswitch_a
    const-class p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI16;

    return-object p0

    .line 203
    :pswitch_b
    const-class p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI8;

    return-object p0

    .line 202
    :pswitch_c
    const-class p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS64;

    return-object p0

    .line 201
    :pswitch_d
    const-class p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS32;

    return-object p0

    .line 200
    :pswitch_e
    const-class p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS16;

    return-object p0

    .line 199
    :pswitch_f
    const-class p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU16;

    return-object p0

    .line 198
    :pswitch_10
    const-class p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS8;

    return-object p0

    .line 197
    :pswitch_11
    const-class p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;

    return-object p0

    .line 196
    :pswitch_12
    const-class p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;

    return-object p0

    .line 195
    :pswitch_13
    const-class p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    return-object p0

    :pswitch_data_0
    .packed-switch 0x1
        :pswitch_9
        :pswitch_8
        :pswitch_7
        :pswitch_6
        :pswitch_5
        :pswitch_4
        :pswitch_3
        :pswitch_2
        :pswitch_1
        :pswitch_0
    .end packed-switch

    :pswitch_data_1
    .packed-switch 0x1
        :pswitch_13
        :pswitch_12
        :pswitch_11
        :pswitch_10
        :pswitch_f
        :pswitch_e
        :pswitch_d
        :pswitch_c
        :pswitch_b
        :pswitch_a
    .end packed-switch
.end method

.method public static il(ILjava/lang/Class;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;
    .locals 2

    .line 102
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

    sget-object v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType$Family;->INTERLEAVED:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType$Family;

    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;->classToType(Ljava/lang/Class;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;

    move-result-object p1

    invoke-direct {v0, v1, p1, p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType$Family;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;I)V

    return-object v0
.end method

.method public static pl(ILjava/lang/Class;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;
    .locals 2

    .line 94
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

    sget-object v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType$Family;->PLANAR:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType$Family;

    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;->classToType(Ljava/lang/Class;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;

    move-result-object p1

    invoke-direct {v0, v1, p1, p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType$Family;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;I)V

    return-object v0
.end method

.method public static single(Ljava/lang/Class;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;
    .locals 3

    .line 86
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

    sget-object v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType$Family;->GRAY:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType$Family;

    invoke-static {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;->classToType(Ljava/lang/Class;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;

    move-result-object p0

    const/4 v2, 0x1

    invoke-direct {v0, v1, p0, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType$Family;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;I)V

    return-object v0
.end method


# virtual methods
.method public createImage(II)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;
    .locals 3

    .line 158
    sget-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType$1;->$SwitchMap$boofcv$struct$image$ImageType$Family:[I

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;->family:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType$Family;

    invoke-virtual {v1}, Ljava/lang/Enum;->ordinal()I

    move-result v1

    aget v0, v0, v1

    const/4 v1, 0x1

    if-eq v0, v1, :cond_2

    const/4 v1, 0x2

    if-eq v0, v1, :cond_1

    const/4 v1, 0x3

    if-ne v0, v1, :cond_0

    .line 161
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;

    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;->getImageClass()Ljava/lang/Class;

    move-result-object v1

    iget v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;->numBands:I

    invoke-direct {v0, v1, p1, p2, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/Planar;-><init>(Ljava/lang/Class;III)V

    return-object v0

    .line 162
    :cond_0
    new-instance p1, Ljava/lang/IllegalArgumentException;

    const-string p2, "Type not yet supported"

    invoke-direct {p1, p2}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p1

    .line 160
    :cond_1
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;->getImageClass()Ljava/lang/Class;

    move-result-object v0

    iget v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;->numBands:I

    invoke-static {v0, p1, p2, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;->create(Ljava/lang/Class;III)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageInterleaved;

    move-result-object p1

    return-object p1

    .line 159
    :cond_2
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;->getImageClass()Ljava/lang/Class;

    move-result-object v0

    invoke-static {v0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;->create(Ljava/lang/Class;II)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    move-result-object p1

    return-object p1
.end method

.method public getDataType()Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;
    .locals 1

    .line 147
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;->dataType:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;

    return-object v0
.end method

.method public getImageClass()Ljava/lang/Class;
    .locals 2

    .line 189
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;->family:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType$Family;

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;->dataType:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;

    invoke-static {v0, v1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;->getImageClass(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType$Family;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;)Ljava/lang/Class;

    move-result-object v0

    return-object v0
.end method

.method public getNumBands()I
    .locals 1

    .line 181
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;->numBands:I

    return v0
.end method

.method public isSameType(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;)Z
    .locals 3

    .line 232
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;->family:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType$Family;

    iget-object v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;->family:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType$Family;

    const/4 v2, 0x0

    if-eq v0, v1, :cond_0

    return v2

    .line 234
    :cond_0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;->dataType:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;

    iget-object v1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;->dataType:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;

    if-eq v0, v1, :cond_1

    return v2

    .line 236
    :cond_1
    iget v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;->numBands:I

    iget p1, p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;->numBands:I

    if-eq v0, p1, :cond_2

    return v2

    :cond_2
    const/4 p1, 0x1

    return p1
.end method

.method public toString()Ljava/lang/String;
    .locals 5

    .line 225
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;->family:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType$Family;

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;->dataType:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageDataType;

    iget v2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;->numBands:I

    new-instance v3, Ljava/lang/StringBuilder;

    invoke-direct {v3}, Ljava/lang/StringBuilder;-><init>()V

    const-string v4, "ImageType( "

    invoke-virtual {v3, v4}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v3, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    const-string v0, " "

    invoke-virtual {v3, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v3, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    invoke-virtual {v3, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v3, v2}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    const-string v0, " )"

    invoke-virtual {v3, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v3}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method
