.class public final Landroidx/room/util/ByteArrayWrapper;
.super Ljava/lang/Object;
.source "ByteArrayWrapper.kt"


# instance fields
.field public final array:[B


# direct methods
.method public constructor <init>([B)V
    .locals 1

    const-string v0, "array"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 23
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput-object p1, p0, Landroidx/room/util/ByteArrayWrapper;->array:[B

    return-void
.end method


# virtual methods
.method public equals(Ljava/lang/Object;)Z
    .locals 1

    if-ne p0, p1, :cond_0

    const/4 p1, 0x1

    return p1

    .line 26
    :cond_0
    instance-of v0, p1, Landroidx/room/util/ByteArrayWrapper;

    if-nez v0, :cond_1

    const/4 p1, 0x0

    return p1

    .line 27
    :cond_1
    iget-object v0, p0, Landroidx/room/util/ByteArrayWrapper;->array:[B

    check-cast p1, Landroidx/room/util/ByteArrayWrapper;

    iget-object p1, p1, Landroidx/room/util/ByteArrayWrapper;->array:[B

    invoke-static {v0, p1}, Ljava/util/Arrays;->equals([B[B)Z

    move-result p1

    return p1
.end method

.method public hashCode()I
    .locals 1

    .line 30
    iget-object v0, p0, Landroidx/room/util/ByteArrayWrapper;->array:[B

    invoke-static {v0}, Ljava/util/Arrays;->hashCode([B)I

    move-result v0

    return v0
.end method
