.class public Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F32;
.super Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F32;
.source "Point2D_F32.java"


# direct methods
.method public constructor <init>()V
    .locals 0

    .line 39
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F32;-><init>()V

    return-void
.end method


# virtual methods
.method public toString()Ljava/lang/String;
    .locals 1

    .line 63
    const-string v0, "P"

    invoke-virtual {p0, v0}, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple2D_F32;->toString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method
