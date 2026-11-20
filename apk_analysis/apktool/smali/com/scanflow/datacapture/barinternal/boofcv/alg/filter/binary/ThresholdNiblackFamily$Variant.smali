.class public final enum Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily$Variant;
.super Ljava/lang/Enum;
.source "ThresholdNiblackFamily.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x4019
    name = "Variant"
.end annotation


# static fields
.field private static final synthetic $VALUES:[Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily$Variant;

.field public static final enum NIBLACK:Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily$Variant;

.field public static final enum SAUVOLA:Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily$Variant;

.field public static final enum WOLF_JOLION:Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily$Variant;


# direct methods
.method private static synthetic $values()[Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily$Variant;
    .locals 3

    .line 214
    sget-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily$Variant;->NIBLACK:Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily$Variant;

    sget-object v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily$Variant;->SAUVOLA:Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily$Variant;

    sget-object v2, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily$Variant;->WOLF_JOLION:Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily$Variant;

    filled-new-array {v0, v1, v2}, [Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily$Variant;

    move-result-object v0

    return-object v0
.end method

.method static constructor <clinit>()V
    .locals 3

    .line 215
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily$Variant;

    const-string v1, "NIBLACK"

    const/4 v2, 0x0

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily$Variant;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily$Variant;->NIBLACK:Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily$Variant;

    .line 216
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily$Variant;

    const-string v1, "SAUVOLA"

    const/4 v2, 0x1

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily$Variant;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily$Variant;->SAUVOLA:Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily$Variant;

    .line 217
    new-instance v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily$Variant;

    const-string v1, "WOLF_JOLION"

    const/4 v2, 0x2

    invoke-direct {v0, v1, v2}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily$Variant;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily$Variant;->WOLF_JOLION:Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily$Variant;

    .line 214
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily$Variant;->$values()[Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily$Variant;

    move-result-object v0

    sput-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily$Variant;->$VALUES:[Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily$Variant;

    return-void
.end method

.method private constructor <init>(Ljava/lang/String;I)V
    .locals 0

    .line 214
    invoke-direct {p0, p1, p2}, Ljava/lang/Enum;-><init>(Ljava/lang/String;I)V

    return-void
.end method

.method public static valueOf(Ljava/lang/String;)Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily$Variant;
    .locals 1

    .line 214
    const-class v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily$Variant;

    invoke-static {v0, p0}, Ljava/lang/Enum;->valueOf(Ljava/lang/Class;Ljava/lang/String;)Ljava/lang/Enum;

    move-result-object p0

    check-cast p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily$Variant;

    return-object p0
.end method

.method public static values()[Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily$Variant;
    .locals 1

    .line 214
    sget-object v0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily$Variant;->$VALUES:[Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily$Variant;

    invoke-virtual {v0}, [Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily$Variant;->clone()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, [Lcom/scanflow/datacapture/barinternal/boofcv/alg/filter/binary/ThresholdNiblackFamily$Variant;

    return-object v0
.end method
