.class public final enum Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType$Family;
.super Ljava/lang/Enum;
.source "ImageType.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x4019
    name = "Family"
.end annotation


# static fields
.field private static final synthetic $VALUES:[Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType$Family;

.field public static final enum GRAY:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType$Family;

.field public static final enum INTERLEAVED:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType$Family;

.field public static final enum PLANAR:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType$Family;


# direct methods
.method private static synthetic $values()[Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType$Family;
    .locals 3

    .line 252
    sget-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType$Family;->GRAY:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType$Family;

    sget-object v1, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType$Family;->PLANAR:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType$Family;

    sget-object v2, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType$Family;->INTERLEAVED:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType$Family;

    filled-new-array {v0, v1, v2}, [Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType$Family;

    move-result-object v0

    return-object v0
.end method

.method static constructor <clinit>()V
    .locals 3

    .line 253
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType$Family;

    const-string v1, "GRAY"

    const/4 v2, 0x0

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType$Family;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType$Family;->GRAY:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType$Family;

    .line 254
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType$Family;

    const-string v1, "PLANAR"

    const/4 v2, 0x1

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType$Family;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType$Family;->PLANAR:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType$Family;

    .line 255
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType$Family;

    const-string v1, "INTERLEAVED"

    const/4 v2, 0x2

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType$Family;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType$Family;->INTERLEAVED:Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType$Family;

    .line 252
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType$Family;->$values()[Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType$Family;

    move-result-object v0

    sput-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType$Family;->$VALUES:[Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType$Family;

    return-void
.end method

.method private constructor <init>(Ljava/lang/String;I)V
    .locals 0

    .line 252
    invoke-direct {p0, p1, p2}, Ljava/lang/Enum;-><init>(Ljava/lang/String;I)V

    return-void
.end method

.method public static valueOf(Ljava/lang/String;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType$Family;
    .locals 1

    .line 252
    const-class v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType$Family;

    invoke-static {v0, p0}, Ljava/lang/Enum;->valueOf(Ljava/lang/Class;Ljava/lang/String;)Ljava/lang/Enum;

    move-result-object p0

    check-cast p0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType$Family;

    return-object p0
.end method

.method public static values()[Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType$Family;
    .locals 1

    .line 252
    sget-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType$Family;->$VALUES:[Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType$Family;

    invoke-virtual {v0}, [Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType$Family;->clone()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, [Lcom/scanflow/datacapture/barinternal/boofcv/struct/image/ImageType$Family;

    return-object v0
.end method
