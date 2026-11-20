.class public final Lcom/scanflow/datacapture/R$styleable;
.super Ljava/lang/Object;
.source "R.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/scanflow/datacapture/R;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x19
    name = "styleable"
.end annotation


# static fields
.field public static final SFCameraView:[I

.field public static final SFCameraView_bottomLeftCornerColor:I = 0x0

.field public static final SFCameraView_bottomRightCornerColor:I = 0x1

.field public static final SFCameraView_cornerRadius:I = 0x2

.field public static final SFCameraView_roundedCorner:I = 0x3

.field public static final SFCameraView_showPointerScanLine:I = 0x4

.field public static final SFCameraView_textCaptureHeightPercentage:I = 0x5

.field public static final SFCameraView_textCaptureWidthPercentage:I = 0x6

.field public static final SFCameraView_topLeftCornerColor:I = 0x7

.field public static final SFCameraView_topRightCornerColor:I = 0x8

.field public static final ViewFinderView:[I

.field public static final ViewFinderView_bottomLeftCornerColor:I = 0x0

.field public static final ViewFinderView_bottomRightCornerColor:I = 0x1

.field public static final ViewFinderView_cornerColor:I = 0x2

.field public static final ViewFinderView_cornerRadius:I = 0x3

.field public static final ViewFinderView_cornerRectHeight:I = 0x4

.field public static final ViewFinderView_cornerRectWidth:I = 0x5

.field public static final ViewFinderView_frameColor:I = 0x6

.field public static final ViewFinderView_frameGravity:I = 0x7

.field public static final ViewFinderView_frameHeight:I = 0x8

.field public static final ViewFinderView_frameLineWidth:I = 0x9

.field public static final ViewFinderView_framePaddingBottom:I = 0xa

.field public static final ViewFinderView_framePaddingLeft:I = 0xb

.field public static final ViewFinderView_framePaddingRight:I = 0xc

.field public static final ViewFinderView_framePaddingTop:I = 0xd

.field public static final ViewFinderView_frameRatio:I = 0xe

.field public static final ViewFinderView_frameWidth:I = 0xf

.field public static final ViewFinderView_gridColumn:I = 0x10

.field public static final ViewFinderView_gridHeight:I = 0x11

.field public static final ViewFinderView_labelText:I = 0x12

.field public static final ViewFinderView_labelTextColor:I = 0x13

.field public static final ViewFinderView_labelTextLocation:I = 0x14

.field public static final ViewFinderView_labelTextPadding:I = 0x15

.field public static final ViewFinderView_labelTextSize:I = 0x16

.field public static final ViewFinderView_labelTextWidth:I = 0x17

.field public static final ViewFinderView_laserColor:I = 0x18

.field public static final ViewFinderView_laserDrawable:I = 0x19

.field public static final ViewFinderView_laserStyle:I = 0x1a

.field public static final ViewFinderView_maskColor:I = 0x1b

.field public static final ViewFinderView_pointColor:I = 0x1c

.field public static final ViewFinderView_pointDrawable:I = 0x1d

.field public static final ViewFinderView_pointRadius:I = 0x1e

.field public static final ViewFinderView_pointStrokeColor:I = 0x1f

.field public static final ViewFinderView_pointStrokeRatio:I = 0x20

.field public static final ViewFinderView_roundedCorner:I = 0x21

.field public static final ViewFinderView_scannerAnimationDelay:I = 0x22

.field public static final ViewFinderView_scannerLineHeight:I = 0x23

.field public static final ViewFinderView_scannerLineMoveDistance:I = 0x24

.field public static final ViewFinderView_showPointAnim:I = 0x25

.field public static final ViewFinderView_topLeftCornerColor:I = 0x26

.field public static final ViewFinderView_topRightCornerColor:I = 0x27

.field public static final ViewFinderView_viewfinderStyle:I = 0x28


# direct methods
.method static constructor <clinit>()V
    .locals 1

    const/16 v0, 0x9

    .line 117
    new-array v0, v0, [I

    fill-array-data v0, :array_0

    sput-object v0, Lcom/scanflow/datacapture/R$styleable;->SFCameraView:[I

    const/16 v0, 0x29

    .line 127
    new-array v0, v0, [I

    fill-array-data v0, :array_1

    sput-object v0, Lcom/scanflow/datacapture/R$styleable;->ViewFinderView:[I

    return-void

    nop

    :array_0
    .array-data 4
        0x7f040087
        0x7f040089
        0x7f04017f
        0x7f040441
        0x7f04047b
        0x7f04051c
        0x7f04051d
        0x7f040574
        0x7f040575
    .end array-data

    :array_1
    .array-data 4
        0x7f040087
        0x7f040089
        0x7f040179
        0x7f04017f
        0x7f040180
        0x7f040181
        0x7f04024c
        0x7f04024d
        0x7f04024e
        0x7f04024f
        0x7f040250
        0x7f040251
        0x7f040252
        0x7f040253
        0x7f040255
        0x7f040256
        0x7f04025a
        0x7f04025b
        0x7f0402cc
        0x7f0402cd
        0x7f0402ce
        0x7f0402cf
        0x7f0402d0
        0x7f0402d1
        0x7f0402d4
        0x7f0402d5
        0x7f0402d6
        0x7f040357
        0x7f040410
        0x7f040411
        0x7f040412
        0x7f040413
        0x7f040414
        0x7f040441
        0x7f040448
        0x7f040449
        0x7f04044a
        0x7f04047a
        0x7f040574
        0x7f040575
        0x7f04059f
    .end array-data
.end method

.method public constructor <init>()V
    .locals 0

    .line 0
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method
