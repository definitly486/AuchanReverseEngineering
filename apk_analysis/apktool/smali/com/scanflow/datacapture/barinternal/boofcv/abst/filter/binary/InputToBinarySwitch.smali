.class public Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/InputToBinarySwitch;
.super Ljava/lang/Object;
.source "InputToBinarySwitch.java"

# interfaces
.implements Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/InputToBinary;


# instance fields
.field alg:Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/InputToBinary;

.field inputType:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

.field work:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;


# direct methods
.method public constructor <init>(Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/InputToBinary;Ljava/lang/Class;)V
    .locals 1

    .line 43
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 44
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/InputToBinarySwitch;->alg:Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/InputToBinary;

    .line 45
    invoke-static {p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;->single(Ljava/lang/Class;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

    move-result-object p2

    iput-object p2, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/InputToBinarySwitch;->inputType:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

    .line 47
    invoke-interface {p1}, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/InputToBinary;->getInputType()Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

    move-result-object p2

    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/InputToBinarySwitch;->inputType:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

    invoke-virtual {p2, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;->isSameType(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;)Z

    move-result p2

    if-nez p2, :cond_0

    .line 48
    invoke-interface {p1}, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/InputToBinary;->getInputType()Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

    move-result-object p1

    const/4 p2, 0x1

    invoke-virtual {p1, p2, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;->createImage(II)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;

    move-result-object p1

    check-cast p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/InputToBinarySwitch;->work:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    :cond_0
    return-void
.end method


# virtual methods
.method public getInputType()Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;
    .locals 1

    .line 66
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/InputToBinarySwitch;->inputType:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;

    return-object v0
.end method

.method public bridge synthetic process(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;)V
    .locals 0

    .line 33
    check-cast p1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    invoke-virtual {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/InputToBinarySwitch;->process(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;)V

    return-void
.end method

.method public process(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;)V
    .locals 1

    .line 54
    invoke-virtual {p2, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;->reshape(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;)V

    .line 55
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/InputToBinarySwitch;->work:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    if-nez v0, :cond_0

    .line 56
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/InputToBinarySwitch;->alg:Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/InputToBinary;

    invoke-interface {v0, p1, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/InputToBinary;->process(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;)V

    return-void

    .line 58
    :cond_0
    invoke-virtual {v0, p1}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;->reshape(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;)V

    .line 59
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/InputToBinarySwitch;->work:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    invoke-static {p1, v0}, Lcom/scanflow/datacapture/barinternal/boofcv/core/image/GConvertImage;->convert(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;)V

    .line 60
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/InputToBinarySwitch;->alg:Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/InputToBinary;

    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/InputToBinarySwitch;->work:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageGray;

    invoke-interface {p1, v0, p2}, Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/InputToBinary;->process(Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageBase;Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/GrayU8;)V

    return-void
.end method
