.class public abstract Lcom/scanflow/datacapture/barinternal/boofcv/core/image/border/FactoryImageBorder;
.super Ljava/lang/Object;
.source "FactoryImageBorder.java"


# direct methods
.method public static single(Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/BorderType;Ljava/lang/Class;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/ImageBorder;
    .locals 2

    .line 134
    sget-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/border/FactoryImageBorder$1;->$SwitchMap$boofcv$struct$border$BorderType:[I

    invoke-virtual {p0}, Ljava/lang/Enum;->ordinal()I

    move-result v1

    aget v0, v0, v1

    packed-switch v0, :pswitch_data_0

    .line 160
    new-instance p1, Ljava/lang/IllegalArgumentException;

    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    const-string v1, "Border type not supported: "

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v0, p0}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p0

    invoke-direct {p1, p0}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p1

    :pswitch_0
    const-wide/16 v0, 0x0

    .line 157
    invoke-static {v0, v1, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/border/FactoryImageBorder;->singleValue(DLjava/lang/Class;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/ImageBorder;

    move-result-object p0

    return-object p0

    .line 153
    :pswitch_1
    new-instance p0, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/border/FactoryImageBorder$$ExternalSyntheticLambda2;

    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/border/FactoryImageBorder$$ExternalSyntheticLambda2;-><init>()V

    goto :goto_0

    .line 149
    :pswitch_2
    new-instance p0, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/border/FactoryImageBorder$$ExternalSyntheticLambda1;

    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/border/FactoryImageBorder$$ExternalSyntheticLambda1;-><init>()V

    goto :goto_0

    .line 145
    :pswitch_3
    new-instance p0, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/border/FactoryImageBorder$$ExternalSyntheticLambda0;

    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/border/FactoryImageBorder$$ExternalSyntheticLambda0;-><init>()V

    .line 163
    :goto_0
    const-class v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    if-ne p1, v0, :cond_0

    .line 164
    new-instance p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/ImageBorder1D_F32;

    invoke-direct {p1, p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/ImageBorder1D_F32;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/FactoryBorderIndex1D;)V

    return-object p1

    .line 165
    :cond_0
    const-class v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;

    if-ne p1, v0, :cond_1

    .line 166
    new-instance p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/ImageBorder1D_F64;

    invoke-direct {p1, p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/ImageBorder1D_F64;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/FactoryBorderIndex1D;)V

    return-object p1

    .line 167
    :cond_1
    const-class v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI;

    invoke-virtual {v0, p1}, Ljava/lang/Class;->isAssignableFrom(Ljava/lang/Class;)Z

    move-result v0

    if-eqz v0, :cond_2

    .line 168
    new-instance p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/ImageBorder1D_S32;

    invoke-direct {p1, p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/ImageBorder1D_S32;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/FactoryBorderIndex1D;)V

    return-object p1

    .line 169
    :cond_2
    const-class v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayS64;

    if-ne p1, v0, :cond_3

    .line 170
    new-instance p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/ImageBorder1D_S64;

    invoke-direct {p1, p0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/ImageBorder1D_S64;-><init>(Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/FactoryBorderIndex1D;)V

    return-object p1

    .line 172
    :cond_3
    new-instance p0, Ljava/lang/IllegalArgumentException;

    invoke-virtual {p1}, Ljava/lang/Class;->getSimpleName()Ljava/lang/String;

    move-result-object p1

    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    const-string v1, "Unknown image type: "

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v0, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p1

    invoke-direct {p0, p1}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p0

    .line 142
    :pswitch_4
    new-instance p0, Ljava/lang/IllegalArgumentException;

    const-string p1, "Normalized can\'t be supported by this border interface"

    invoke-direct {p0, p1}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p0

    .line 136
    :pswitch_5
    new-instance p0, Ljava/lang/IllegalArgumentException;

    const-string p1, "Skip border can\'t be implemented here and has to be done externally. Instead pass in EXTENDED and manually skip over the in a pixel by pixel basis."

    invoke-direct {p0, p1}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p0

    nop

    :pswitch_data_0
    .packed-switch 0x1
        :pswitch_5
        :pswitch_4
        :pswitch_3
        :pswitch_2
        :pswitch_1
        :pswitch_0
    .end packed-switch
.end method

.method public static singleValue(DLjava/lang/Class;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/border/ImageBorder;
    .locals 1

    .line 255
    const-class v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF32;

    if-ne p2, v0, :cond_0

    .line 256
    new-instance p2, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/ImageBorderValue$Value_F32;

    double-to-float p0, p0

    invoke-direct {p2, p0}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/ImageBorderValue$Value_F32;-><init>(F)V

    return-object p2

    .line 257
    :cond_0
    const-class v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayF64;

    if-ne p2, v0, :cond_1

    .line 258
    new-instance p2, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/ImageBorderValue$Value_F64;

    invoke-direct {p2, p0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/ImageBorderValue$Value_F64;-><init>(D)V

    return-object p2

    .line 259
    :cond_1
    const-class v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayI;

    invoke-virtual {v0, p2}, Ljava/lang/Class;->isAssignableFrom(Ljava/lang/Class;)Z

    move-result v0

    if-eqz v0, :cond_2

    .line 260
    new-instance p2, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/ImageBorderValue$Value_I;

    double-to-int p0, p0

    invoke-direct {p2, p0}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/ImageBorderValue$Value_I;-><init>(I)V

    return-object p2

    .line 262
    :cond_2
    new-instance p0, Ljava/lang/IllegalArgumentException;

    invoke-virtual {p2}, Ljava/lang/Class;->getSimpleName()Ljava/lang/String;

    move-result-object p1

    new-instance p2, Ljava/lang/StringBuilder;

    invoke-direct {p2}, Ljava/lang/StringBuilder;-><init>()V

    const-string v0, "Unknown image type: "

    invoke-virtual {p2, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {p2, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {p2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p1

    invoke-direct {p0, p1}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p0
.end method
