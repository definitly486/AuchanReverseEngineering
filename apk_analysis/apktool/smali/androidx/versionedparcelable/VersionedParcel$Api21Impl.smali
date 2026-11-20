.class abstract Landroidx/versionedparcelable/VersionedParcel$Api21Impl;
.super Ljava/lang/Object;
.source "VersionedParcel.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Landroidx/versionedparcelable/VersionedParcel;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x1a
    name = "Api21Impl"
.end annotation


# direct methods
.method static readSize(Landroidx/versionedparcelable/VersionedParcel;)Landroid/util/Size;
    .locals 2

    .line 1659
    invoke-virtual {p0}, Landroidx/versionedparcelable/VersionedParcel;->readBoolean()Z

    move-result v0

    if-eqz v0, :cond_0

    .line 1660
    invoke-virtual {p0}, Landroidx/versionedparcelable/VersionedParcel;->readInt()I

    move-result v0

    .line 1661
    invoke-virtual {p0}, Landroidx/versionedparcelable/VersionedParcel;->readInt()I

    move-result p0

    .line 1662
    new-instance v1, Landroid/util/Size;

    invoke-direct {v1, v0, p0}, Landroid/util/Size;-><init>(II)V

    return-object v1

    :cond_0
    const/4 p0, 0x0

    return-object p0
.end method

.method static readSizeF(Landroidx/versionedparcelable/VersionedParcel;)Landroid/util/SizeF;
    .locals 2

    .line 1668
    invoke-virtual {p0}, Landroidx/versionedparcelable/VersionedParcel;->readBoolean()Z

    move-result v0

    if-eqz v0, :cond_0

    .line 1669
    invoke-virtual {p0}, Landroidx/versionedparcelable/VersionedParcel;->readFloat()F

    move-result v0

    .line 1670
    invoke-virtual {p0}, Landroidx/versionedparcelable/VersionedParcel;->readFloat()F

    move-result p0

    .line 1671
    new-instance v1, Landroid/util/SizeF;

    invoke-direct {v1, v0, p0}, Landroid/util/SizeF;-><init>(FF)V

    return-object v1

    :cond_0
    const/4 p0, 0x0

    return-object p0
.end method

.method static writeSize(Landroidx/versionedparcelable/VersionedParcel;Landroid/util/Size;)V
    .locals 1

    if-eqz p1, :cond_0

    const/4 v0, 0x1

    goto :goto_0

    :cond_0
    const/4 v0, 0x0

    .line 1643
    :goto_0
    invoke-virtual {p0, v0}, Landroidx/versionedparcelable/VersionedParcel;->writeBoolean(Z)V

    if-eqz p1, :cond_1

    .line 1645
    invoke-virtual {p1}, Landroid/util/Size;->getWidth()I

    move-result v0

    invoke-virtual {p0, v0}, Landroidx/versionedparcelable/VersionedParcel;->writeInt(I)V

    .line 1646
    invoke-virtual {p1}, Landroid/util/Size;->getHeight()I

    move-result p1

    invoke-virtual {p0, p1}, Landroidx/versionedparcelable/VersionedParcel;->writeInt(I)V

    :cond_1
    return-void
.end method

.method static writeSizeF(Landroidx/versionedparcelable/VersionedParcel;Landroid/util/SizeF;)V
    .locals 1

    if-eqz p1, :cond_0

    const/4 v0, 0x1

    goto :goto_0

    :cond_0
    const/4 v0, 0x0

    .line 1651
    :goto_0
    invoke-virtual {p0, v0}, Landroidx/versionedparcelable/VersionedParcel;->writeBoolean(Z)V

    if-eqz p1, :cond_1

    .line 1653
    invoke-virtual {p1}, Landroid/util/SizeF;->getWidth()F

    move-result v0

    invoke-virtual {p0, v0}, Landroidx/versionedparcelable/VersionedParcel;->writeFloat(F)V

    .line 1654
    invoke-virtual {p1}, Landroid/util/SizeF;->getHeight()F

    move-result p1

    invoke-virtual {p0, p1}, Landroidx/versionedparcelable/VersionedParcel;->writeFloat(F)V

    :cond_1
    return-void
.end method
