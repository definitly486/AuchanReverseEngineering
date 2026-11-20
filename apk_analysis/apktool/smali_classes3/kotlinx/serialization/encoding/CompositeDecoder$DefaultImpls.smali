.class public final Lkotlinx/serialization/encoding/CompositeDecoder$DefaultImpls;
.super Ljava/lang/Object;
.source "Decoding.kt"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lkotlinx/serialization/encoding/CompositeDecoder;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x19
    name = "DefaultImpls"
.end annotation


# direct methods
.method public static decodeCollectionSize(Lkotlinx/serialization/encoding/CompositeDecoder;Lkotlinx/serialization/descriptors/SerialDescriptor;)I
    .locals 1
    .annotation runtime Ljava/lang/Deprecated;
    .end annotation

    const-string v0, "descriptor"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 428
    invoke-static {p0, p1}, Lkotlinx/serialization/encoding/CompositeDecoder;->access$decodeCollectionSize$jd(Lkotlinx/serialization/encoding/CompositeDecoder;Lkotlinx/serialization/descriptors/SerialDescriptor;)I

    move-result p0

    return p0
.end method

.method public static decodeSequentially(Lkotlinx/serialization/encoding/CompositeDecoder;)Z
    .locals 0
    .annotation runtime Ljava/lang/Deprecated;
    .end annotation

    .annotation runtime Lkotlinx/serialization/ExperimentalSerializationApi;
    .end annotation

    .line 364
    invoke-static {p0}, Lkotlinx/serialization/encoding/CompositeDecoder;->access$decodeSequentially$jd(Lkotlinx/serialization/encoding/CompositeDecoder;)Z

    move-result p0

    return p0
.end method
