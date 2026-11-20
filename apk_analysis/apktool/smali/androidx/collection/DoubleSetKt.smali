.class public final Landroidx/collection/DoubleSetKt;
.super Ljava/lang/Object;
.source "DoubleSet.kt"


# static fields
.field private static final EmptyDoubleArray:[D


# direct methods
.method static constructor <clinit>()V
    .locals 1

    const/4 v0, 0x0

    .line 28
    new-array v0, v0, [D

    sput-object v0, Landroidx/collection/DoubleSetKt;->EmptyDoubleArray:[D

    return-void
.end method

.method public static final getEmptyDoubleArray()[D
    .locals 1

    .line 28
    sget-object v0, Landroidx/collection/DoubleSetKt;->EmptyDoubleArray:[D

    return-object v0
.end method
