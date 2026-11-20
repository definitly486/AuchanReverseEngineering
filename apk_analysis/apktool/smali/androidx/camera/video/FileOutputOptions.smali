.class public final Landroidx/camera/video/FileOutputOptions;
.super Landroidx/camera/video/OutputOptions;
.source "FileOutputOptions.java"


# virtual methods
.method public equals(Ljava/lang/Object;)Z
    .locals 1

    if-ne p0, p1, :cond_0

    const/4 p1, 0x1

    return p1

    .line 63
    :cond_0
    instance-of v0, p1, Landroidx/camera/video/FileOutputOptions;

    if-nez v0, :cond_1

    const/4 p1, 0x0

    return p1

    .line 66
    :cond_1
    check-cast p1, Landroidx/camera/video/FileOutputOptions;

    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    const/4 p1, 0x0

    throw p1
.end method

.method public getFile()Ljava/io/File;
    .locals 1

    const/4 v0, 0x0

    .line 47
    throw v0
.end method

.method public hashCode()I
    .locals 1

    const/4 v0, 0x0

    .line 72
    throw v0
.end method

.method public toString()Ljava/lang/String;
    .locals 1

    const/4 v0, 0x0

    .line 54
    throw v0
.end method
