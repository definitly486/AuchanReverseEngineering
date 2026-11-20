.class public abstract Lcom/scanflow/datacapture/barinternal/georegression/misc/GrlConstants;
.super Ljava/lang/Object;
.source "GrlConstants.java"


# static fields
.field public static DCONV_TOL_A:D = 0.0

.field public static DCONV_TOL_B:D = 0.0

.field public static EPS:D = 0.0

.field public static FCONV_TOL_A:F = 0.0f

.field public static FCONV_TOL_B:F = 0.0f

.field public static F_EPS:F = 0.0f

.field public static F_PI:F = 3.1415927f

.field public static PI2:D = 6.283185307179586

.field public static TEST_F32:F = 1.0E-4f

.field public static TEST_SQ_F32:F

.field public static TEST_SQ_F64:D


# direct methods
.method static constructor <clinit>()V
    .locals 4

    const-wide v0, 0x3e45798ee2308c3aL    # 1.0E-8

    .line 45
    invoke-static {v0, v1}, Ljava/lang/Math;->sqrt(D)D

    move-result-wide v0

    sput-wide v0, Lcom/scanflow/datacapture/barinternal/georegression/misc/GrlConstants;->TEST_SQ_F64:D

    .line 46
    sget v0, Lcom/scanflow/datacapture/barinternal/georegression/misc/GrlConstants;->TEST_F32:F

    float-to-double v0, v0

    invoke-static {v0, v1}, Ljava/lang/Math;->sqrt(D)D

    move-result-wide v0

    double-to-float v0, v0

    sput v0, Lcom/scanflow/datacapture/barinternal/georegression/misc/GrlConstants;->TEST_SQ_F32:F

    const v0, 0x3727c5ac    # 1.0E-5f

    .line 49
    sput v0, Lcom/scanflow/datacapture/barinternal/georegression/misc/GrlConstants;->FCONV_TOL_A:F

    const-wide v0, 0x3ddb7cdfd9d7bdbbL    # 1.0E-10

    .line 50
    sput-wide v0, Lcom/scanflow/datacapture/barinternal/georegression/misc/GrlConstants;->DCONV_TOL_A:D

    const v0, 0x358637bd    # 1.0E-6f

    .line 51
    sput v0, Lcom/scanflow/datacapture/barinternal/georegression/misc/GrlConstants;->FCONV_TOL_B:F

    const-wide v0, 0x3d719799812dea11L    # 1.0E-12

    .line 52
    sput-wide v0, Lcom/scanflow/datacapture/barinternal/georegression/misc/GrlConstants;->DCONV_TOL_B:D

    const-wide/high16 v0, 0x4000000000000000L    # 2.0

    const-wide/high16 v2, -0x3fcb000000000000L    # -21.0

    .line 54
    invoke-static {v0, v1, v2, v3}, Ljava/lang/Math;->pow(DD)D

    move-result-wide v0

    double-to-float v0, v0

    sput v0, Lcom/scanflow/datacapture/barinternal/georegression/misc/GrlConstants;->F_EPS:F

    .line 55
    sget-wide v0, Lcom/scanflow/datacapture/barinternal/org/ejml/UtilEjml;->EPS:D

    sput-wide v0, Lcom/scanflow/datacapture/barinternal/georegression/misc/GrlConstants;->EPS:D

    return-void
.end method
