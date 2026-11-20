.class public Lcom/scanflow/datacapture/utils/FrameMetadata;
.super Ljava/lang/Object;
.source "SourceFile"


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/scanflow/datacapture/utils/FrameMetadata$Builder;
    }
.end annotation


# instance fields
.field private final height:I

.field private final rotation:I

.field private final width:I


# direct methods
.method private constructor <init>(III)V
    .locals 0

    .line 1
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput p1, p0, Lcom/scanflow/datacapture/utils/FrameMetadata;->width:I

    iput p2, p0, Lcom/scanflow/datacapture/utils/FrameMetadata;->height:I

    iput p3, p0, Lcom/scanflow/datacapture/utils/FrameMetadata;->rotation:I

    return-void
.end method

.method public synthetic constructor <init>(IIILcom/scanflow/datacapture/utils/FrameMetadata$1;)V
    .locals 0

    .line 2
    invoke-direct {p0, p1, p2, p3}, Lcom/scanflow/datacapture/utils/FrameMetadata;-><init>(III)V

    return-void
.end method


# virtual methods
.method public getHeight()I
    .locals 1

    .line 0
    iget v0, p0, Lcom/scanflow/datacapture/utils/FrameMetadata;->height:I

    return v0
.end method

.method public getRotation()I
    .locals 1

    .line 0
    iget v0, p0, Lcom/scanflow/datacapture/utils/FrameMetadata;->rotation:I

    return v0
.end method

.method public getWidth()I
    .locals 1

    .line 0
    iget v0, p0, Lcom/scanflow/datacapture/utils/FrameMetadata;->width:I

    return v0
.end method
