.class public final Landroidx/camera/video/MediaStoreOutputOptions;
.super Landroidx/camera/video/OutputOptions;
.source "MediaStoreOutputOptions.java"


# static fields
.field public static final EMPTY_CONTENT_VALUES:Landroid/content/ContentValues;


# direct methods
.method static constructor <clinit>()V
    .locals 1

    .line 65
    new-instance v0, Landroid/content/ContentValues;

    invoke-direct {v0}, Landroid/content/ContentValues;-><init>()V

    sput-object v0, Landroidx/camera/video/MediaStoreOutputOptions;->EMPTY_CONTENT_VALUES:Landroid/content/ContentValues;

    return-void
.end method


# virtual methods
.method public equals(Ljava/lang/Object;)Z
    .locals 1

    if-ne p0, p1, :cond_0

    const/4 p1, 0x1

    return p1

    .line 118
    :cond_0
    instance-of v0, p1, Landroidx/camera/video/MediaStoreOutputOptions;

    if-nez v0, :cond_1

    const/4 p1, 0x0

    return p1

    .line 121
    :cond_1
    check-cast p1, Landroidx/camera/video/MediaStoreOutputOptions;

    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    const/4 p1, 0x0

    throw p1
.end method

.method public getCollectionUri()Landroid/net/Uri;
    .locals 1

    const/4 v0, 0x0

    .line 92
    throw v0
.end method

.method public getContentResolver()Landroid/content/ContentResolver;
    .locals 1

    const/4 v0, 0x0

    .line 82
    throw v0
.end method

.method public getContentValues()Landroid/content/ContentValues;
    .locals 1

    const/4 v0, 0x0

    .line 102
    throw v0
.end method

.method public hashCode()I
    .locals 1

    const/4 v0, 0x0

    .line 127
    throw v0
.end method

.method public toString()Ljava/lang/String;
    .locals 1

    const/4 v0, 0x0

    .line 109
    throw v0
.end method
