.class public Lcom/scanflow/datacapture/barinternal/boofcv/struct/geo/AssociatedPair3D;
.super Ljava/lang/Object;
.source "AssociatedPair3D.java"


# instance fields
.field public p1:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point3D_F64;

.field public p2:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point3D_F64;


# direct methods
.method public constructor <init>()V
    .locals 1

    .line 38
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 39
    new-instance v0, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point3D_F64;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point3D_F64;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/geo/AssociatedPair3D;->p1:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point3D_F64;

    .line 40
    new-instance v0, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point3D_F64;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point3D_F64;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/geo/AssociatedPair3D;->p2:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point3D_F64;

    return-void
.end method


# virtual methods
.method public setTo(DDDDDD)Lcom/scanflow/datacapture/barinternal/boofcv/struct/geo/AssociatedPair3D;
    .locals 8

    .line 108
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/geo/AssociatedPair3D;->p1:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point3D_F64;

    move-wide v1, p1

    move-wide v3, p3

    move-wide v5, p5

    invoke-virtual/range {v0 .. v6}, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple3D_F64;->setTo(DDD)Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple3D_F64;

    .line 109
    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/geo/AssociatedPair3D;->p2:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point3D_F64;

    move-wide v2, p7

    move-wide/from16 v4, p9

    move-wide/from16 v6, p11

    invoke-virtual/range {v1 .. v7}, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple3D_F64;->setTo(DDD)Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple3D_F64;

    return-object p0
.end method

.method public toString()Ljava/lang/String;
    .locals 4

    .line 139
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/geo/AssociatedPair3D;->p1:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point3D_F64;

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/geo/AssociatedPair3D;->p2:Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point3D_F64;

    new-instance v2, Ljava/lang/StringBuilder;

    invoke-direct {v2}, Ljava/lang/StringBuilder;-><init>()V

    const-string v3, "AssociatedPair3D{p1="

    invoke-virtual {v2, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v2, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    const-string v0, ", p2="

    invoke-virtual {v2, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v2, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    const-string v0, "}"

    invoke-virtual {v2, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v2}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method
