.class public Lcom/scanflow/datacapture/utils/FrameMetadata$Builder;
.super Ljava/lang/Object;
.source "SourceFile"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/scanflow/datacapture/utils/FrameMetadata;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x9
    name = "Builder"
.end annotation


# instance fields
.field private height:I

.field private rotation:I

.field private width:I


# direct methods
.method public constructor <init>()V
    .locals 0

    .line 0
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public build()Lcom/scanflow/datacapture/utils/FrameMetadata;
    .locals 5

    .line 0
    new-instance v0, Lcom/scanflow/datacapture/utils/FrameMetadata;

    iget v1, p0, Lcom/scanflow/datacapture/utils/FrameMetadata$Builder;->width:I

    iget v2, p0, Lcom/scanflow/datacapture/utils/FrameMetadata$Builder;->height:I

    iget v3, p0, Lcom/scanflow/datacapture/utils/FrameMetadata$Builder;->rotation:I

    const/4 v4, 0x0

    invoke-direct {v0, v1, v2, v3, v4}, Lcom/scanflow/datacapture/utils/FrameMetadata;-><init>(IIILcom/scanflow/datacapture/utils/FrameMetadata$1;)V

    return-object v0
.end method

.method public setHeight(I)Lcom/scanflow/datacapture/utils/FrameMetadata$Builder;
    .locals 0

    .line 0
    iput p1, p0, Lcom/scanflow/datacapture/utils/FrameMetadata$Builder;->height:I

    return-object p0
.end method

.method public setRotation(I)Lcom/scanflow/datacapture/utils/FrameMetadata$Builder;
    .locals 0

    .line 0
    iput p1, p0, Lcom/scanflow/datacapture/utils/FrameMetadata$Builder;->rotation:I

    return-object p0
.end method

.method public setWidth(I)Lcom/scanflow/datacapture/utils/FrameMetadata$Builder;
    .locals 0

    .line 0
    iput p1, p0, Lcom/scanflow/datacapture/utils/FrameMetadata$Builder;->width:I

    return-object p0
.end method
