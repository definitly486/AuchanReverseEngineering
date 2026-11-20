.class public final enum Lcom/redmadrobot/inputmask/helper/AffinityCalculationStrategy;
.super Ljava/lang/Enum;
.source "AffinityCalculationStrategy.kt"


# annotations
.annotation system Ldalvik/annotation/Signature;
    value = {
        "Ljava/lang/Enum<",
        "Lcom/redmadrobot/inputmask/helper/AffinityCalculationStrategy;",
        ">;"
    }
.end annotation


# static fields
.field private static final synthetic $VALUES:[Lcom/redmadrobot/inputmask/helper/AffinityCalculationStrategy;

.field public static final enum CAPACITY:Lcom/redmadrobot/inputmask/helper/AffinityCalculationStrategy;

.field public static final enum EXTRACTED_VALUE_CAPACITY:Lcom/redmadrobot/inputmask/helper/AffinityCalculationStrategy;

.field public static final enum PREFIX:Lcom/redmadrobot/inputmask/helper/AffinityCalculationStrategy;

.field public static final enum WHOLE_STRING:Lcom/redmadrobot/inputmask/helper/AffinityCalculationStrategy;


# direct methods
.method static constructor <clinit>()V
    .locals 6

    .line 0
    new-instance v0, Lcom/redmadrobot/inputmask/helper/AffinityCalculationStrategy;

    const-string v1, "WHOLE_STRING"

    const/4 v2, 0x0

    invoke-direct {v0, v1, v2}, Lcom/redmadrobot/inputmask/helper/AffinityCalculationStrategy;-><init>(Ljava/lang/String;I)V

    sput-object v0, Lcom/redmadrobot/inputmask/helper/AffinityCalculationStrategy;->WHOLE_STRING:Lcom/redmadrobot/inputmask/helper/AffinityCalculationStrategy;

    new-instance v1, Lcom/redmadrobot/inputmask/helper/AffinityCalculationStrategy;

    const-string v2, "PREFIX"

    const/4 v3, 0x1

    invoke-direct {v1, v2, v3}, Lcom/redmadrobot/inputmask/helper/AffinityCalculationStrategy;-><init>(Ljava/lang/String;I)V

    sput-object v1, Lcom/redmadrobot/inputmask/helper/AffinityCalculationStrategy;->PREFIX:Lcom/redmadrobot/inputmask/helper/AffinityCalculationStrategy;

    new-instance v2, Lcom/redmadrobot/inputmask/helper/AffinityCalculationStrategy;

    const-string v3, "CAPACITY"

    const/4 v4, 0x2

    invoke-direct {v2, v3, v4}, Lcom/redmadrobot/inputmask/helper/AffinityCalculationStrategy;-><init>(Ljava/lang/String;I)V

    sput-object v2, Lcom/redmadrobot/inputmask/helper/AffinityCalculationStrategy;->CAPACITY:Lcom/redmadrobot/inputmask/helper/AffinityCalculationStrategy;

    new-instance v3, Lcom/redmadrobot/inputmask/helper/AffinityCalculationStrategy;

    const-string v4, "EXTRACTED_VALUE_CAPACITY"

    const/4 v5, 0x3

    invoke-direct {v3, v4, v5}, Lcom/redmadrobot/inputmask/helper/AffinityCalculationStrategy;-><init>(Ljava/lang/String;I)V

    sput-object v3, Lcom/redmadrobot/inputmask/helper/AffinityCalculationStrategy;->EXTRACTED_VALUE_CAPACITY:Lcom/redmadrobot/inputmask/helper/AffinityCalculationStrategy;

    filled-new-array {v0, v1, v2, v3}, [Lcom/redmadrobot/inputmask/helper/AffinityCalculationStrategy;

    move-result-object v0

    sput-object v0, Lcom/redmadrobot/inputmask/helper/AffinityCalculationStrategy;->$VALUES:[Lcom/redmadrobot/inputmask/helper/AffinityCalculationStrategy;

    return-void
.end method

.method private constructor <init>(Ljava/lang/String;I)V
    .locals 0
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()V"
        }
    .end annotation

    .line 10
    invoke-direct {p0, p1, p2}, Ljava/lang/Enum;-><init>(Ljava/lang/String;I)V

    return-void
.end method

.method private final prefixIntersection(Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;
    .locals 5

    .line 132
    invoke-interface {p1}, Ljava/lang/CharSequence;->length()I

    move-result v0

    if-nez v0, :cond_0

    goto :goto_0

    :cond_0
    invoke-interface {p2}, Ljava/lang/CharSequence;->length()I

    move-result v0

    if-nez v0, :cond_1

    :goto_0
    const-string p1, ""

    return-object p1

    :cond_1
    const/4 v0, 0x0

    move v1, v0

    .line 135
    :goto_1
    invoke-virtual {p1}, Ljava/lang/String;->length()I

    move-result v2

    const-string v3, "(this as java.lang.Strin\u2026ing(startIndex, endIndex)"

    if-ge v1, v2, :cond_3

    invoke-virtual {p2}, Ljava/lang/String;->length()I

    move-result v2

    if-ge v1, v2, :cond_3

    .line 136
    invoke-virtual {p1, v1}, Ljava/lang/String;->charAt(I)C

    move-result v2

    invoke-virtual {p2, v1}, Ljava/lang/String;->charAt(I)C

    move-result v4

    if-ne v2, v4, :cond_2

    add-int/lit8 v1, v1, 0x1

    goto :goto_1

    .line 139
    :cond_2
    invoke-virtual {p1, v0, v1}, Ljava/lang/String;->substring(II)Ljava/lang/String;

    move-result-object p1

    invoke-static {p1, v3}, Lkotlin/jvm/internal/Intrinsics;->checkExpressionValueIsNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    return-object p1

    .line 143
    :cond_3
    invoke-virtual {p1, v0, v1}, Ljava/lang/String;->substring(II)Ljava/lang/String;

    move-result-object p1

    invoke-static {p1, v3}, Lkotlin/jvm/internal/Intrinsics;->checkExpressionValueIsNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    return-object p1
.end method

.method public static valueOf(Ljava/lang/String;)Lcom/redmadrobot/inputmask/helper/AffinityCalculationStrategy;
    .locals 1

    .line 0
    const-class v0, Lcom/redmadrobot/inputmask/helper/AffinityCalculationStrategy;

    invoke-static {v0, p0}, Ljava/lang/Enum;->valueOf(Ljava/lang/Class;Ljava/lang/String;)Ljava/lang/Enum;

    move-result-object p0

    check-cast p0, Lcom/redmadrobot/inputmask/helper/AffinityCalculationStrategy;

    return-object p0
.end method

.method public static values()[Lcom/redmadrobot/inputmask/helper/AffinityCalculationStrategy;
    .locals 1

    .line 0
    sget-object v0, Lcom/redmadrobot/inputmask/helper/AffinityCalculationStrategy;->$VALUES:[Lcom/redmadrobot/inputmask/helper/AffinityCalculationStrategy;

    invoke-virtual {v0}, [Lcom/redmadrobot/inputmask/helper/AffinityCalculationStrategy;->clone()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, [Lcom/redmadrobot/inputmask/helper/AffinityCalculationStrategy;

    return-object v0
.end method


# virtual methods
.method public final calculateAffinityOfMask(Lcom/redmadrobot/inputmask/helper/Mask;Lcom/redmadrobot/inputmask/model/CaretString;)I
    .locals 3

    const-string v0, "mask"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkParameterIsNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "text"

    invoke-static {p2, v0}, Lkotlin/jvm/internal/Intrinsics;->checkParameterIsNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    .line 107
    sget-object v0, Lcom/redmadrobot/inputmask/helper/AffinityCalculationStrategy$WhenMappings;->$EnumSwitchMapping$0:[I

    invoke-virtual {p0}, Ljava/lang/Enum;->ordinal()I

    move-result v1

    aget v0, v0, v1

    const/4 v1, 0x1

    if-eq v0, v1, :cond_5

    const/4 v1, 0x2

    if-eq v0, v1, :cond_4

    const/4 v1, 0x3

    const/high16 v2, -0x80000000

    if-eq v0, v1, :cond_2

    const/4 v1, 0x4

    if-ne v0, v1, :cond_1

    .line 121
    invoke-virtual {p1, p2}, Lcom/redmadrobot/inputmask/helper/Mask;->apply(Lcom/redmadrobot/inputmask/model/CaretString;)Lcom/redmadrobot/inputmask/helper/Mask$Result;

    move-result-object p2

    invoke-virtual {p2}, Lcom/redmadrobot/inputmask/helper/Mask$Result;->getExtractedValue()Ljava/lang/String;

    move-result-object p2

    invoke-virtual {p2}, Ljava/lang/String;->length()I

    move-result p2

    .line 122
    invoke-virtual {p1}, Lcom/redmadrobot/inputmask/helper/Mask;->totalValueLength()I

    move-result v0

    if-le p2, v0, :cond_0

    return v2

    .line 125
    :cond_0
    invoke-virtual {p1}, Lcom/redmadrobot/inputmask/helper/Mask;->totalValueLength()I

    move-result p1

    :goto_0
    sub-int/2addr p2, p1

    return p2

    .line 122
    :cond_1
    new-instance p1, Lcom/scanflow/datacapture/barinternal/kotlin/NoWhenBranchMatchedException;

    invoke-direct {p1}, Lcom/scanflow/datacapture/barinternal/kotlin/NoWhenBranchMatchedException;-><init>()V

    throw p1

    .line 114
    :cond_2
    invoke-virtual {p2}, Lcom/redmadrobot/inputmask/model/CaretString;->getString()Ljava/lang/String;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/String;->length()I

    move-result v0

    invoke-virtual {p1}, Lcom/redmadrobot/inputmask/helper/Mask;->totalTextLength()I

    move-result v1

    if-le v0, v1, :cond_3

    return v2

    .line 117
    :cond_3
    invoke-virtual {p2}, Lcom/redmadrobot/inputmask/model/CaretString;->getString()Ljava/lang/String;

    move-result-object p2

    invoke-virtual {p2}, Ljava/lang/String;->length()I

    move-result p2

    invoke-virtual {p1}, Lcom/redmadrobot/inputmask/helper/Mask;->totalTextLength()I

    move-result p1

    goto :goto_0

    .line 110
    :cond_4
    invoke-virtual {p1, p2}, Lcom/redmadrobot/inputmask/helper/Mask;->apply(Lcom/redmadrobot/inputmask/model/CaretString;)Lcom/redmadrobot/inputmask/helper/Mask$Result;

    move-result-object p1

    invoke-virtual {p1}, Lcom/redmadrobot/inputmask/helper/Mask$Result;->getFormattedText()Lcom/redmadrobot/inputmask/model/CaretString;

    move-result-object p1

    invoke-virtual {p1}, Lcom/redmadrobot/inputmask/model/CaretString;->getString()Ljava/lang/String;

    move-result-object p1

    .line 112
    invoke-virtual {p2}, Lcom/redmadrobot/inputmask/model/CaretString;->getString()Ljava/lang/String;

    move-result-object p2

    invoke-direct {p0, p1, p2}, Lcom/redmadrobot/inputmask/helper/AffinityCalculationStrategy;->prefixIntersection(Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;

    move-result-object p1

    invoke-virtual {p1}, Ljava/lang/String;->length()I

    move-result p1

    return p1

    .line 108
    :cond_5
    invoke-virtual {p1, p2}, Lcom/redmadrobot/inputmask/helper/Mask;->apply(Lcom/redmadrobot/inputmask/model/CaretString;)Lcom/redmadrobot/inputmask/helper/Mask$Result;

    move-result-object p1

    invoke-virtual {p1}, Lcom/redmadrobot/inputmask/helper/Mask$Result;->getAffinity()I

    move-result p1

    return p1
.end method
