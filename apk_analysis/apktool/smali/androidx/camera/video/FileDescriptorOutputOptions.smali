.class public final Landroidx/camera/video/FileDescriptorOutputOptions;
.super Landroidx/camera/video/OutputOptions;
.source "FileDescriptorOutputOptions.java"


# virtual methods
.method public equals(Ljava/lang/Object;)Z
    .locals 1

    if-ne p0, p1, :cond_0

    const/4 p1, 0x1

    return p1

    .line 71
    :cond_0
    instance-of v0, p1, Landroidx/camera/video/FileDescriptorOutputOptions;

    if-nez v0, :cond_1

    const/4 p1, 0x0

    return p1

    .line 74
    :cond_1
    check-cast p1, Landroidx/camera/video/FileDescriptorOutputOptions;

    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    const/4 p1, 0x0

    throw p1
.end method

.method public getParcelFileDescriptor()Landroid/os/ParcelFileDescriptor;
    .locals 1

    const/4 v0, 0x0

    .line 55
    throw v0
.end method

.method public hashCode()I
    .locals 1

    const/4 v0, 0x0

    .line 80
    throw v0
.end method

.method public toString()Ljava/lang/String;
    .locals 1

    const/4 v0, 0x0

    .line 62
    throw v0
.end method
