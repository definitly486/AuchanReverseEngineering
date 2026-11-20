.class public abstract Lcom/scanflow/datacapture/barinternal/org/ejml/EjmlParameters;
.super Ljava/lang/Object;
.source "EjmlParameters.java"


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/scanflow/datacapture/barinternal/org/ejml/EjmlParameters$MemoryUsage;
    }
.end annotation


# static fields
.field public static BLOCK_WIDTH:I

.field public static BLOCK_WIDTH_CHOL:I

.field public static CMULT_COLUMN_SWITCH:I

.field public static CMULT_TRANAB_COLUMN_SWITCH:I

.field public static MEMORY:Lcom/scanflow/datacapture/barinternal/org/ejml/EjmlParameters$MemoryUsage;

.field public static MULT_COLUMN_SWITCH:I

.field public static MULT_INNER_SWITCH:I

.field public static MULT_TRANAB_COLUMN_SWITCH:I

.field public static SWITCH_BLOCK64_CHOLESKY:I

.field public static SWITCH_BLOCK64_QR:I

.field public static TRANSPOSE_SWITCH:I


# direct methods
.method static constructor <clinit>()V
    .locals 2

    .line 36
    sget-object v0, Lcom/scanflow/datacapture/barinternal/org/ejml/EjmlParameters$MemoryUsage;->FASTER:Lcom/scanflow/datacapture/barinternal/org/ejml/EjmlParameters$MemoryUsage;

    sput-object v0, Lcom/scanflow/datacapture/barinternal/org/ejml/EjmlParameters;->MEMORY:Lcom/scanflow/datacapture/barinternal/org/ejml/EjmlParameters$MemoryUsage;

    const/16 v0, 0x3c

    .line 48
    sput v0, Lcom/scanflow/datacapture/barinternal/org/ejml/EjmlParameters;->BLOCK_WIDTH:I

    const/16 v0, 0x14

    .line 49
    sput v0, Lcom/scanflow/datacapture/barinternal/org/ejml/EjmlParameters;->BLOCK_WIDTH_CHOL:I

    const/16 v1, 0x177

    .line 51
    sput v1, Lcom/scanflow/datacapture/barinternal/org/ejml/EjmlParameters;->TRANSPOSE_SWITCH:I

    const/16 v1, 0xf

    .line 56
    sput v1, Lcom/scanflow/datacapture/barinternal/org/ejml/EjmlParameters;->MULT_COLUMN_SWITCH:I

    const/16 v1, 0x28

    .line 57
    sput v1, Lcom/scanflow/datacapture/barinternal/org/ejml/EjmlParameters;->MULT_TRANAB_COLUMN_SWITCH:I

    const/16 v1, 0x64

    .line 58
    sput v1, Lcom/scanflow/datacapture/barinternal/org/ejml/EjmlParameters;->MULT_INNER_SWITCH:I

    const/4 v1, 0x7

    .line 60
    sput v1, Lcom/scanflow/datacapture/barinternal/org/ejml/EjmlParameters;->CMULT_COLUMN_SWITCH:I

    .line 61
    sput v0, Lcom/scanflow/datacapture/barinternal/org/ejml/EjmlParameters;->CMULT_TRANAB_COLUMN_SWITCH:I

    const/16 v0, 0x3e8

    .line 73
    sput v0, Lcom/scanflow/datacapture/barinternal/org/ejml/EjmlParameters;->SWITCH_BLOCK64_CHOLESKY:I

    const/16 v0, 0x5dc

    .line 75
    sput v0, Lcom/scanflow/datacapture/barinternal/org/ejml/EjmlParameters;->SWITCH_BLOCK64_QR:I

    return-void
.end method
