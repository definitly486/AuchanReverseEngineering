.class public final Landroidx/collection/SieveCacheKt;
.super Ljava/lang/Object;
.source "SieveCache.kt"


# static fields
.field private static final EmptyNodes:[J


# direct methods
.method static constructor <clinit>()V
    .locals 1

    const/4 v0, 0x0

    .line 39
    new-array v0, v0, [J

    sput-object v0, Landroidx/collection/SieveCacheKt;->EmptyNodes:[J

    return-void
.end method

.method public static final getDst(J)I
    .locals 2

    .line 0
    const-wide v0, 0xffffffffL

    and-long/2addr p0, v0

    long-to-int p0, p0

    return p0
.end method

.method public static final getEmptyNodes()[J
    .locals 1

    .line 39
    sget-object v0, Landroidx/collection/SieveCacheKt;->EmptyNodes:[J

    return-object v0
.end method

.method public static final getNextNode(J)I
    .locals 2

    .line 0
    const-wide/32 v0, 0x7fffffff

    and-long/2addr p0, v0

    long-to-int p0, p0

    return p0
.end method

.method public static final getPreviousNode(J)I
    .locals 2

    .line 0
    const/16 v0, 0x1f

    shr-long/2addr p0, v0

    const-wide/32 v0, 0x7fffffff

    and-long/2addr p0, v0

    long-to-int p0, p0

    return p0
.end method

.method public static final getSrc(J)I
    .locals 2

    .line 0
    const/16 v0, 0x20

    shr-long/2addr p0, v0

    const-wide v0, 0xffffffffL

    and-long/2addr p0, v0

    long-to-int p0, p0

    return p0
.end method

.method public static final getVisited(J)I
    .locals 2

    .line 0
    const/16 v0, 0x3e

    shr-long/2addr p0, v0

    const-wide/16 v0, 0x1

    and-long/2addr p0, v0

    long-to-int p0, p0

    return p0
.end method
