.class public Lcom/redmadrobot/inputmask/MaskedTextChangedListener;
.super Ljava/lang/Object;
.source "MaskedTextChangedListener.kt"

# interfaces
.implements Landroid/text/TextWatcher;
.implements Landroid/view/View$OnFocusChangeListener;


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/redmadrobot/inputmask/MaskedTextChangedListener$ValueListener;,
        Lcom/redmadrobot/inputmask/MaskedTextChangedListener$Companion;
    }
.end annotation


# static fields
.field public static final Companion:Lcom/redmadrobot/inputmask/MaskedTextChangedListener$Companion;


# instance fields
.field private affineFormats:Ljava/util/List;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/util/List<",
            "Ljava/lang/String;",
            ">;"
        }
    .end annotation
.end field

.field private affinityCalculationStrategy:Lcom/redmadrobot/inputmask/helper/AffinityCalculationStrategy;

.field private afterText:Ljava/lang/String;

.field private autocomplete:Z

.field private autoskip:Z

.field private caretPosition:I

.field private customNotations:Ljava/util/List;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/util/List<",
            "Lcom/redmadrobot/inputmask/model/Notation;",
            ">;"
        }
    .end annotation
.end field

.field private final field:Ljava/lang/ref/WeakReference;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/lang/ref/WeakReference<",
            "Landroid/widget/EditText;",
            ">;"
        }
    .end annotation
.end field

.field private listener:Landroid/text/TextWatcher;

.field private primaryFormat:Ljava/lang/String;

.field private rightToLeft:Z

.field private valueListener:Lcom/redmadrobot/inputmask/MaskedTextChangedListener$ValueListener;


# direct methods
.method static constructor <clinit>()V
    .locals 2

    .line 0
    new-instance v0, Lcom/redmadrobot/inputmask/MaskedTextChangedListener$Companion;

    const/4 v1, 0x0

    invoke-direct {v0, v1}, Lcom/redmadrobot/inputmask/MaskedTextChangedListener$Companion;-><init>(Lkotlin/jvm/internal/DefaultConstructorMarker;)V

    sput-object v0, Lcom/redmadrobot/inputmask/MaskedTextChangedListener;->Companion:Lcom/redmadrobot/inputmask/MaskedTextChangedListener$Companion;

    return-void
.end method

.method public constructor <init>(Ljava/lang/String;Landroid/widget/EditText;)V
    .locals 1

    const-string v0, "format"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkParameterIsNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "field"

    invoke-static {p2, v0}, Lkotlin/jvm/internal/Intrinsics;->checkParameterIsNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    const/4 v0, 0x0

    .line 51
    invoke-direct {p0, p1, p2, v0}, Lcom/redmadrobot/inputmask/MaskedTextChangedListener;-><init>(Ljava/lang/String;Landroid/widget/EditText;Lcom/redmadrobot/inputmask/MaskedTextChangedListener$ValueListener;)V

    return-void
.end method

.method public constructor <init>(Ljava/lang/String;Landroid/widget/EditText;Landroid/text/TextWatcher;Lcom/redmadrobot/inputmask/MaskedTextChangedListener$ValueListener;)V
    .locals 7

    const-string v0, "format"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkParameterIsNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "field"

    invoke-static {p2, v0}, Lkotlin/jvm/internal/Intrinsics;->checkParameterIsNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    const/4 v3, 0x1

    move-object v1, p0

    move-object v2, p1

    move-object v4, p2

    move-object v5, p3

    move-object v6, p4

    .line 63
    invoke-direct/range {v1 .. v6}, Lcom/redmadrobot/inputmask/MaskedTextChangedListener;-><init>(Ljava/lang/String;ZLandroid/widget/EditText;Landroid/text/TextWatcher;Lcom/redmadrobot/inputmask/MaskedTextChangedListener$ValueListener;)V

    return-void
.end method

.method public constructor <init>(Ljava/lang/String;Landroid/widget/EditText;Lcom/redmadrobot/inputmask/MaskedTextChangedListener$ValueListener;)V
    .locals 1

    const-string v0, "format"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkParameterIsNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "field"

    invoke-static {p2, v0}, Lkotlin/jvm/internal/Intrinsics;->checkParameterIsNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    const/4 v0, 0x0

    .line 57
    invoke-direct {p0, p1, p2, v0, p3}, Lcom/redmadrobot/inputmask/MaskedTextChangedListener;-><init>(Ljava/lang/String;Landroid/widget/EditText;Landroid/text/TextWatcher;Lcom/redmadrobot/inputmask/MaskedTextChangedListener$ValueListener;)V

    return-void
.end method

.method public constructor <init>(Ljava/lang/String;Ljava/util/List;Landroid/widget/EditText;)V
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/String;",
            "Ljava/util/List<",
            "Ljava/lang/String;",
            ">;",
            "Landroid/widget/EditText;",
            ")V"
        }
    .end annotation

    const-string v0, "primaryFormat"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkParameterIsNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "affineFormats"

    invoke-static {p2, v0}, Lkotlin/jvm/internal/Intrinsics;->checkParameterIsNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "field"

    invoke-static {p3, v0}, Lkotlin/jvm/internal/Intrinsics;->checkParameterIsNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    const/4 v0, 0x0

    .line 81
    invoke-direct {p0, p1, p2, p3, v0}, Lcom/redmadrobot/inputmask/MaskedTextChangedListener;-><init>(Ljava/lang/String;Ljava/util/List;Landroid/widget/EditText;Lcom/redmadrobot/inputmask/MaskedTextChangedListener$ValueListener;)V

    return-void
.end method

.method public constructor <init>(Ljava/lang/String;Ljava/util/List;Landroid/widget/EditText;Landroid/text/TextWatcher;Lcom/redmadrobot/inputmask/MaskedTextChangedListener$ValueListener;)V
    .locals 8
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/String;",
            "Ljava/util/List<",
            "Ljava/lang/String;",
            ">;",
            "Landroid/widget/EditText;",
            "Landroid/text/TextWatcher;",
            "Lcom/redmadrobot/inputmask/MaskedTextChangedListener$ValueListener;",
            ")V"
        }
    .end annotation

    const-string v0, "primaryFormat"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkParameterIsNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "affineFormats"

    invoke-static {p2, v0}, Lkotlin/jvm/internal/Intrinsics;->checkParameterIsNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "field"

    invoke-static {p3, v0}, Lkotlin/jvm/internal/Intrinsics;->checkParameterIsNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    const/4 v4, 0x1

    move-object v1, p0

    move-object v2, p1

    move-object v3, p2

    move-object v5, p3

    move-object v6, p4

    move-object v7, p5

    .line 96
    invoke-direct/range {v1 .. v7}, Lcom/redmadrobot/inputmask/MaskedTextChangedListener;-><init>(Ljava/lang/String;Ljava/util/List;ZLandroid/widget/EditText;Landroid/text/TextWatcher;Lcom/redmadrobot/inputmask/MaskedTextChangedListener$ValueListener;)V

    return-void
.end method

.method public constructor <init>(Ljava/lang/String;Ljava/util/List;Landroid/widget/EditText;Lcom/redmadrobot/inputmask/MaskedTextChangedListener$ValueListener;)V
    .locals 7
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/String;",
            "Ljava/util/List<",
            "Ljava/lang/String;",
            ">;",
            "Landroid/widget/EditText;",
            "Lcom/redmadrobot/inputmask/MaskedTextChangedListener$ValueListener;",
            ")V"
        }
    .end annotation

    const-string v0, "primaryFormat"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkParameterIsNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "affineFormats"

    invoke-static {p2, v0}, Lkotlin/jvm/internal/Intrinsics;->checkParameterIsNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "field"

    invoke-static {p3, v0}, Lkotlin/jvm/internal/Intrinsics;->checkParameterIsNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    const/4 v5, 0x0

    move-object v1, p0

    move-object v2, p1

    move-object v3, p2

    move-object v4, p3

    move-object v6, p4

    .line 87
    invoke-direct/range {v1 .. v6}, Lcom/redmadrobot/inputmask/MaskedTextChangedListener;-><init>(Ljava/lang/String;Ljava/util/List;Landroid/widget/EditText;Landroid/text/TextWatcher;Lcom/redmadrobot/inputmask/MaskedTextChangedListener$ValueListener;)V

    return-void
.end method

.method public constructor <init>(Ljava/lang/String;Ljava/util/List;Lcom/redmadrobot/inputmask/helper/AffinityCalculationStrategy;ZLandroid/widget/EditText;Landroid/text/TextWatcher;Lcom/redmadrobot/inputmask/MaskedTextChangedListener$ValueListener;)V
    .locals 14
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/String;",
            "Ljava/util/List<",
            "Ljava/lang/String;",
            ">;",
            "Lcom/redmadrobot/inputmask/helper/AffinityCalculationStrategy;",
            "Z",
            "Landroid/widget/EditText;",
            "Landroid/text/TextWatcher;",
            "Lcom/redmadrobot/inputmask/MaskedTextChangedListener$ValueListener;",
            ")V"
        }
    .end annotation

    const-string v0, "primaryFormat"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkParameterIsNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "affineFormats"

    move-object/from16 v3, p2

    invoke-static {v3, v0}, Lkotlin/jvm/internal/Intrinsics;->checkParameterIsNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "affinityCalculationStrategy"

    move-object/from16 v5, p3

    invoke-static {v5, v0}, Lkotlin/jvm/internal/Intrinsics;->checkParameterIsNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "field"

    move-object/from16 v8, p5

    invoke-static {v8, v0}, Lkotlin/jvm/internal/Intrinsics;->checkParameterIsNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    .line 119
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/CollectionsKt;->emptyList()Ljava/util/List;

    move-result-object v4

    const/16 v12, 0x200

    const/4 v13, 0x0

    const/4 v7, 0x0

    const/4 v11, 0x0

    move-object v1, p0

    move-object v2, p1

    move/from16 v6, p4

    move-object/from16 v9, p6

    move-object/from16 v10, p7

    .line 118
    invoke-direct/range {v1 .. v13}, Lcom/redmadrobot/inputmask/MaskedTextChangedListener;-><init>(Ljava/lang/String;Ljava/util/List;Ljava/util/List;Lcom/redmadrobot/inputmask/helper/AffinityCalculationStrategy;ZZLandroid/widget/EditText;Landroid/text/TextWatcher;Lcom/redmadrobot/inputmask/MaskedTextChangedListener$ValueListener;ZILkotlin/jvm/internal/DefaultConstructorMarker;)V

    return-void
.end method

.method public constructor <init>(Ljava/lang/String;Ljava/util/List;Ljava/util/List;Lcom/redmadrobot/inputmask/helper/AffinityCalculationStrategy;ZZLandroid/widget/EditText;Landroid/text/TextWatcher;Lcom/redmadrobot/inputmask/MaskedTextChangedListener$ValueListener;Z)V
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/String;",
            "Ljava/util/List<",
            "Ljava/lang/String;",
            ">;",
            "Ljava/util/List<",
            "Lcom/redmadrobot/inputmask/model/Notation;",
            ">;",
            "Lcom/redmadrobot/inputmask/helper/AffinityCalculationStrategy;",
            "ZZ",
            "Landroid/widget/EditText;",
            "Landroid/text/TextWatcher;",
            "Lcom/redmadrobot/inputmask/MaskedTextChangedListener$ValueListener;",
            "Z)V"
        }
    .end annotation

    const-string v0, "primaryFormat"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkParameterIsNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "affineFormats"

    invoke-static {p2, v0}, Lkotlin/jvm/internal/Intrinsics;->checkParameterIsNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "customNotations"

    invoke-static {p3, v0}, Lkotlin/jvm/internal/Intrinsics;->checkParameterIsNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "affinityCalculationStrategy"

    invoke-static {p4, v0}, Lkotlin/jvm/internal/Intrinsics;->checkParameterIsNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "field"

    invoke-static {p7, v0}, Lkotlin/jvm/internal/Intrinsics;->checkParameterIsNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    .line 22
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput-object p1, p0, Lcom/redmadrobot/inputmask/MaskedTextChangedListener;->primaryFormat:Ljava/lang/String;

    iput-object p2, p0, Lcom/redmadrobot/inputmask/MaskedTextChangedListener;->affineFormats:Ljava/util/List;

    iput-object p3, p0, Lcom/redmadrobot/inputmask/MaskedTextChangedListener;->customNotations:Ljava/util/List;

    iput-object p4, p0, Lcom/redmadrobot/inputmask/MaskedTextChangedListener;->affinityCalculationStrategy:Lcom/redmadrobot/inputmask/helper/AffinityCalculationStrategy;

    iput-boolean p5, p0, Lcom/redmadrobot/inputmask/MaskedTextChangedListener;->autocomplete:Z

    iput-boolean p6, p0, Lcom/redmadrobot/inputmask/MaskedTextChangedListener;->autoskip:Z

    iput-object p8, p0, Lcom/redmadrobot/inputmask/MaskedTextChangedListener;->listener:Landroid/text/TextWatcher;

    iput-object p9, p0, Lcom/redmadrobot/inputmask/MaskedTextChangedListener;->valueListener:Lcom/redmadrobot/inputmask/MaskedTextChangedListener$ValueListener;

    iput-boolean p10, p0, Lcom/redmadrobot/inputmask/MaskedTextChangedListener;->rightToLeft:Z

    .line 42
    const-string p1, ""

    iput-object p1, p0, Lcom/redmadrobot/inputmask/MaskedTextChangedListener;->afterText:Ljava/lang/String;

    .line 45
    new-instance p1, Ljava/lang/ref/WeakReference;

    invoke-direct {p1, p7}, Ljava/lang/ref/WeakReference;-><init>(Ljava/lang/Object;)V

    iput-object p1, p0, Lcom/redmadrobot/inputmask/MaskedTextChangedListener;->field:Ljava/lang/ref/WeakReference;

    return-void
.end method

.method public synthetic constructor <init>(Ljava/lang/String;Ljava/util/List;Ljava/util/List;Lcom/redmadrobot/inputmask/helper/AffinityCalculationStrategy;ZZLandroid/widget/EditText;Landroid/text/TextWatcher;Lcom/redmadrobot/inputmask/MaskedTextChangedListener$ValueListener;ZILkotlin/jvm/internal/DefaultConstructorMarker;)V
    .locals 11

    move/from16 v0, p11

    and-int/lit8 v1, v0, 0x2

    if-eqz v1, :cond_0

    .line 24
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/CollectionsKt;->emptyList()Ljava/util/List;

    move-result-object p2

    :cond_0
    move-object v2, p2

    and-int/lit8 p2, v0, 0x4

    if-eqz p2, :cond_1

    .line 25
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/CollectionsKt;->emptyList()Ljava/util/List;

    move-result-object p2

    move-object v3, p2

    goto :goto_0

    :cond_1
    move-object v3, p3

    :goto_0
    and-int/lit8 p2, v0, 0x8

    if-eqz p2, :cond_2

    .line 26
    sget-object p2, Lcom/redmadrobot/inputmask/helper/AffinityCalculationStrategy;->WHOLE_STRING:Lcom/redmadrobot/inputmask/helper/AffinityCalculationStrategy;

    move-object v4, p2

    goto :goto_1

    :cond_2
    move-object v4, p4

    :goto_1
    and-int/lit8 p2, v0, 0x10

    if-eqz p2, :cond_3

    const/4 p2, 0x1

    move v5, p2

    goto :goto_2

    :cond_3
    move/from16 v5, p5

    :goto_2
    and-int/lit8 p2, v0, 0x20

    const/4 v1, 0x0

    if-eqz p2, :cond_4

    move v6, v1

    goto :goto_3

    :cond_4
    move/from16 v6, p6

    :goto_3
    and-int/lit16 p2, v0, 0x80

    const/4 v7, 0x0

    if-eqz p2, :cond_5

    move-object v8, v7

    goto :goto_4

    :cond_5
    move-object/from16 v8, p8

    :goto_4
    and-int/lit16 p2, v0, 0x100

    if-eqz p2, :cond_6

    move-object v9, v7

    goto :goto_5

    :cond_6
    move-object/from16 v9, p9

    :goto_5
    and-int/lit16 p2, v0, 0x200

    if-eqz p2, :cond_7

    move v10, v1

    move-object v0, p0

    move-object/from16 v7, p7

    move-object v1, p1

    goto :goto_6

    :cond_7
    move/from16 v10, p10

    move-object v0, p0

    move-object v1, p1

    move-object/from16 v7, p7

    .line 32
    :goto_6
    invoke-direct/range {v0 .. v10}, Lcom/redmadrobot/inputmask/MaskedTextChangedListener;-><init>(Ljava/lang/String;Ljava/util/List;Ljava/util/List;Lcom/redmadrobot/inputmask/helper/AffinityCalculationStrategy;ZZLandroid/widget/EditText;Landroid/text/TextWatcher;Lcom/redmadrobot/inputmask/MaskedTextChangedListener$ValueListener;Z)V

    return-void
.end method

.method public constructor <init>(Ljava/lang/String;Ljava/util/List;ZLandroid/widget/EditText;Landroid/text/TextWatcher;Lcom/redmadrobot/inputmask/MaskedTextChangedListener$ValueListener;)V
    .locals 9
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/String;",
            "Ljava/util/List<",
            "Ljava/lang/String;",
            ">;Z",
            "Landroid/widget/EditText;",
            "Landroid/text/TextWatcher;",
            "Lcom/redmadrobot/inputmask/MaskedTextChangedListener$ValueListener;",
            ")V"
        }
    .end annotation

    const-string v0, "primaryFormat"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkParameterIsNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "affineFormats"

    invoke-static {p2, v0}, Lkotlin/jvm/internal/Intrinsics;->checkParameterIsNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "field"

    invoke-static {p4, v0}, Lkotlin/jvm/internal/Intrinsics;->checkParameterIsNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    .line 106
    sget-object v4, Lcom/redmadrobot/inputmask/helper/AffinityCalculationStrategy;->WHOLE_STRING:Lcom/redmadrobot/inputmask/helper/AffinityCalculationStrategy;

    move-object v1, p0

    move-object v2, p1

    move-object v3, p2

    move v5, p3

    move-object v6, p4

    move-object v7, p5

    move-object v8, p6

    .line 105
    invoke-direct/range {v1 .. v8}, Lcom/redmadrobot/inputmask/MaskedTextChangedListener;-><init>(Ljava/lang/String;Ljava/util/List;Lcom/redmadrobot/inputmask/helper/AffinityCalculationStrategy;ZLandroid/widget/EditText;Landroid/text/TextWatcher;Lcom/redmadrobot/inputmask/MaskedTextChangedListener$ValueListener;)V

    return-void
.end method

.method public constructor <init>(Ljava/lang/String;ZLandroid/widget/EditText;Landroid/text/TextWatcher;Lcom/redmadrobot/inputmask/MaskedTextChangedListener$ValueListener;)V
    .locals 14

    const-string v0, "format"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkParameterIsNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "field"

    move-object/from16 v8, p3

    invoke-static {v8, v0}, Lkotlin/jvm/internal/Intrinsics;->checkParameterIsNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    .line 73
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/CollectionsKt;->emptyList()Ljava/util/List;

    move-result-object v3

    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/CollectionsKt;->emptyList()Ljava/util/List;

    move-result-object v4

    sget-object v5, Lcom/redmadrobot/inputmask/helper/AffinityCalculationStrategy;->WHOLE_STRING:Lcom/redmadrobot/inputmask/helper/AffinityCalculationStrategy;

    const/16 v12, 0x200

    const/4 v13, 0x0

    const/4 v7, 0x0

    const/4 v11, 0x0

    move-object v1, p0

    move-object v2, p1

    move/from16 v6, p2

    move-object/from16 v9, p4

    move-object/from16 v10, p5

    .line 72
    invoke-direct/range {v1 .. v13}, Lcom/redmadrobot/inputmask/MaskedTextChangedListener;-><init>(Ljava/lang/String;Ljava/util/List;Ljava/util/List;Lcom/redmadrobot/inputmask/helper/AffinityCalculationStrategy;ZZLandroid/widget/EditText;Landroid/text/TextWatcher;Lcom/redmadrobot/inputmask/MaskedTextChangedListener$ValueListener;ZILkotlin/jvm/internal/DefaultConstructorMarker;)V

    return-void
.end method

.method private final calculateAffinity(Lcom/redmadrobot/inputmask/helper/Mask;Lcom/redmadrobot/inputmask/model/CaretString;)I
    .locals 1

    .line 289
    iget-object v0, p0, Lcom/redmadrobot/inputmask/MaskedTextChangedListener;->affinityCalculationStrategy:Lcom/redmadrobot/inputmask/helper/AffinityCalculationStrategy;

    invoke-virtual {v0, p1, p2}, Lcom/redmadrobot/inputmask/helper/AffinityCalculationStrategy;->calculateAffinityOfMask(Lcom/redmadrobot/inputmask/helper/Mask;Lcom/redmadrobot/inputmask/model/CaretString;)I

    move-result p1

    return p1
.end method

.method private final getPrimaryMask()Lcom/redmadrobot/inputmask/helper/Mask;
    .locals 2

    .line 40
    iget-object v0, p0, Lcom/redmadrobot/inputmask/MaskedTextChangedListener;->primaryFormat:Ljava/lang/String;

    iget-object v1, p0, Lcom/redmadrobot/inputmask/MaskedTextChangedListener;->customNotations:Ljava/util/List;

    invoke-direct {p0, v0, v1}, Lcom/redmadrobot/inputmask/MaskedTextChangedListener;->maskGetOrCreate(Ljava/lang/String;Ljava/util/List;)Lcom/redmadrobot/inputmask/helper/Mask;

    move-result-object v0

    return-object v0
.end method

.method private final maskGetOrCreate(Ljava/lang/String;Ljava/util/List;)Lcom/redmadrobot/inputmask/helper/Mask;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/String;",
            "Ljava/util/List<",
            "Lcom/redmadrobot/inputmask/model/Notation;",
            ">;)",
            "Lcom/redmadrobot/inputmask/helper/Mask;"
        }
    .end annotation

    .line 279
    iget-boolean v0, p0, Lcom/redmadrobot/inputmask/MaskedTextChangedListener;->rightToLeft:Z

    if-eqz v0, :cond_0

    .line 280
    sget-object v0, Lcom/redmadrobot/inputmask/helper/RTLMask;->Factory:Lcom/redmadrobot/inputmask/helper/RTLMask$Factory;

    invoke-virtual {v0, p1, p2}, Lcom/redmadrobot/inputmask/helper/RTLMask$Factory;->getOrCreate(Ljava/lang/String;Ljava/util/List;)Lcom/redmadrobot/inputmask/helper/RTLMask;

    move-result-object p1

    return-object p1

    .line 282
    :cond_0
    sget-object v0, Lcom/redmadrobot/inputmask/helper/Mask;->Factory:Lcom/redmadrobot/inputmask/helper/Mask$Factory;

    invoke-virtual {v0, p1, p2}, Lcom/redmadrobot/inputmask/helper/Mask$Factory;->getOrCreate(Ljava/lang/String;Ljava/util/List;)Lcom/redmadrobot/inputmask/helper/Mask;

    move-result-object p1

    return-object p1
.end method

.method private final pickMask(Lcom/redmadrobot/inputmask/model/CaretString;)Lcom/redmadrobot/inputmask/helper/Mask;
    .locals 6

    .line 245
    iget-object v0, p0, Lcom/redmadrobot/inputmask/MaskedTextChangedListener;->affineFormats:Ljava/util/List;

    invoke-interface {v0}, Ljava/util/List;->isEmpty()Z

    move-result v0

    if-eqz v0, :cond_0

    invoke-direct {p0}, Lcom/redmadrobot/inputmask/MaskedTextChangedListener;->getPrimaryMask()Lcom/redmadrobot/inputmask/helper/Mask;

    move-result-object p1

    return-object p1

    .line 249
    :cond_0
    invoke-direct {p0}, Lcom/redmadrobot/inputmask/MaskedTextChangedListener;->getPrimaryMask()Lcom/redmadrobot/inputmask/helper/Mask;

    move-result-object v0

    invoke-direct {p0, v0, p1}, Lcom/redmadrobot/inputmask/MaskedTextChangedListener;->calculateAffinity(Lcom/redmadrobot/inputmask/helper/Mask;Lcom/redmadrobot/inputmask/model/CaretString;)I

    move-result v0

    .line 251
    new-instance v1, Ljava/util/ArrayList;

    invoke-direct {v1}, Ljava/util/ArrayList;-><init>()V

    .line 252
    iget-object v2, p0, Lcom/redmadrobot/inputmask/MaskedTextChangedListener;->affineFormats:Ljava/util/List;

    invoke-interface {v2}, Ljava/util/List;->iterator()Ljava/util/Iterator;

    move-result-object v2

    :goto_0
    invoke-interface {v2}, Ljava/util/Iterator;->hasNext()Z

    move-result v3

    if-eqz v3, :cond_1

    invoke-interface {v2}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v3

    check-cast v3, Ljava/lang/String;

    .line 253
    iget-object v4, p0, Lcom/redmadrobot/inputmask/MaskedTextChangedListener;->customNotations:Ljava/util/List;

    invoke-direct {p0, v3, v4}, Lcom/redmadrobot/inputmask/MaskedTextChangedListener;->maskGetOrCreate(Ljava/lang/String;Ljava/util/List;)Lcom/redmadrobot/inputmask/helper/Mask;

    move-result-object v3

    .line 254
    invoke-direct {p0, v3, p1}, Lcom/redmadrobot/inputmask/MaskedTextChangedListener;->calculateAffinity(Lcom/redmadrobot/inputmask/helper/Mask;Lcom/redmadrobot/inputmask/model/CaretString;)I

    move-result v4

    .line 255
    new-instance v5, Lcom/redmadrobot/inputmask/MaskedTextChangedListener$pickMask$MaskAffinity;

    invoke-direct {v5, v3, v4}, Lcom/redmadrobot/inputmask/MaskedTextChangedListener$pickMask$MaskAffinity;-><init>(Lcom/redmadrobot/inputmask/helper/Mask;I)V

    invoke-interface {v1, v5}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    goto :goto_0

    .line 368
    :cond_1
    invoke-interface {v1}, Ljava/util/List;->size()I

    move-result p1

    const/4 v2, 0x1

    if-le p1, v2, :cond_2

    new-instance p1, Lcom/redmadrobot/inputmask/MaskedTextChangedListener$pickMask$$inlined$sortByDescending$1;

    invoke-direct {p1}, Lcom/redmadrobot/inputmask/MaskedTextChangedListener$pickMask$$inlined$sortByDescending$1;-><init>()V

    invoke-static {v1, p1}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/CollectionsKt;->sortWith(Ljava/util/List;Ljava/util/Comparator;)V

    .line 262
    :cond_2
    invoke-virtual {v1}, Ljava/util/ArrayList;->size()I

    move-result p1

    const/4 v2, 0x0

    move v3, v2

    :goto_1
    if-ge v3, p1, :cond_4

    invoke-virtual {v1, v3}, Ljava/util/ArrayList;->get(I)Ljava/lang/Object;

    move-result-object v4

    add-int/lit8 v3, v3, 0x1

    check-cast v4, Lcom/redmadrobot/inputmask/MaskedTextChangedListener$pickMask$MaskAffinity;

    .line 263
    invoke-virtual {v4}, Lcom/redmadrobot/inputmask/MaskedTextChangedListener$pickMask$MaskAffinity;->getAffinity()I

    move-result v4

    if-lt v0, v4, :cond_3

    goto :goto_2

    :cond_3
    add-int/lit8 v2, v2, 0x1

    goto :goto_1

    :cond_4
    const/4 v2, -0x1

    :goto_2
    if-ltz v2, :cond_5

    .line 270
    new-instance p1, Lcom/redmadrobot/inputmask/MaskedTextChangedListener$pickMask$MaskAffinity;

    invoke-direct {p0}, Lcom/redmadrobot/inputmask/MaskedTextChangedListener;->getPrimaryMask()Lcom/redmadrobot/inputmask/helper/Mask;

    move-result-object v3

    invoke-direct {p1, v3, v0}, Lcom/redmadrobot/inputmask/MaskedTextChangedListener$pickMask$MaskAffinity;-><init>(Lcom/redmadrobot/inputmask/helper/Mask;I)V

    invoke-interface {v1, v2, p1}, Ljava/util/List;->add(ILjava/lang/Object;)V

    goto :goto_3

    .line 272
    :cond_5
    new-instance p1, Lcom/redmadrobot/inputmask/MaskedTextChangedListener$pickMask$MaskAffinity;

    invoke-direct {p0}, Lcom/redmadrobot/inputmask/MaskedTextChangedListener;->getPrimaryMask()Lcom/redmadrobot/inputmask/helper/Mask;

    move-result-object v2

    invoke-direct {p1, v2, v0}, Lcom/redmadrobot/inputmask/MaskedTextChangedListener$pickMask$MaskAffinity;-><init>(Lcom/redmadrobot/inputmask/helper/Mask;I)V

    invoke-interface {v1, p1}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    .line 275
    :goto_3
    invoke-static {v1}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/CollectionsKt;->first(Ljava/util/List;)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Lcom/redmadrobot/inputmask/MaskedTextChangedListener$pickMask$MaskAffinity;

    invoke-virtual {p1}, Lcom/redmadrobot/inputmask/MaskedTextChangedListener$pickMask$MaskAffinity;->getMask()Lcom/redmadrobot/inputmask/helper/Mask;

    move-result-object p1

    return-object p1
.end method

.method public static synthetic setText$default(Lcom/redmadrobot/inputmask/MaskedTextChangedListener;Ljava/lang/String;Landroid/widget/EditText;Ljava/lang/Boolean;ILjava/lang/Object;)Lcom/redmadrobot/inputmask/helper/Mask$Result;
    .locals 0

    if-nez p5, :cond_1

    and-int/lit8 p4, p4, 0x4

    if-eqz p4, :cond_0

    const/4 p3, 0x0

    .line 142
    :cond_0
    invoke-virtual {p0, p1, p2, p3}, Lcom/redmadrobot/inputmask/MaskedTextChangedListener;->setText(Ljava/lang/String;Landroid/widget/EditText;Ljava/lang/Boolean;)Lcom/redmadrobot/inputmask/helper/Mask$Result;

    move-result-object p0

    return-object p0

    .line 0
    :cond_1
    new-instance p0, Ljava/lang/UnsupportedOperationException;

    const-string p1, "Super calls with default arguments not supported in this target, function: setText"

    invoke-direct {p0, p1}, Ljava/lang/UnsupportedOperationException;-><init>(Ljava/lang/String;)V

    throw p0
.end method

.method public static synthetic setText$default(Lcom/redmadrobot/inputmask/MaskedTextChangedListener;Ljava/lang/String;Ljava/lang/Boolean;ILjava/lang/Object;)Lcom/redmadrobot/inputmask/helper/Mask$Result;
    .locals 0

    if-nez p4, :cond_1

    and-int/lit8 p3, p3, 0x2

    if-eqz p3, :cond_0

    const/4 p2, 0x0

    .line 127
    :cond_0
    invoke-virtual {p0, p1, p2}, Lcom/redmadrobot/inputmask/MaskedTextChangedListener;->setText(Ljava/lang/String;Ljava/lang/Boolean;)Lcom/redmadrobot/inputmask/helper/Mask$Result;

    move-result-object p0

    return-object p0

    .line 0
    :cond_1
    new-instance p0, Ljava/lang/UnsupportedOperationException;

    const-string p1, "Super calls with default arguments not supported in this target, function: setText"

    invoke-direct {p0, p1}, Ljava/lang/UnsupportedOperationException;-><init>(Ljava/lang/String;)V

    throw p0
.end method


# virtual methods
.method public final acceptableTextLength()I
    .locals 1

    .line 167
    invoke-direct {p0}, Lcom/redmadrobot/inputmask/MaskedTextChangedListener;->getPrimaryMask()Lcom/redmadrobot/inputmask/helper/Mask;

    move-result-object v0

    invoke-virtual {v0}, Lcom/redmadrobot/inputmask/helper/Mask;->acceptableTextLength()I

    move-result v0

    return v0
.end method

.method public final acceptableValueLength()I
    .locals 1

    .line 181
    invoke-direct {p0}, Lcom/redmadrobot/inputmask/MaskedTextChangedListener;->getPrimaryMask()Lcom/redmadrobot/inputmask/helper/Mask;

    move-result-object v0

    invoke-virtual {v0}, Lcom/redmadrobot/inputmask/helper/Mask;->acceptableValueLength()I

    move-result v0

    return v0
.end method

.method public afterTextChanged(Landroid/text/Editable;)V
    .locals 3

    .line 191
    iget-object v0, p0, Lcom/redmadrobot/inputmask/MaskedTextChangedListener;->field:Ljava/lang/ref/WeakReference;

    invoke-virtual {v0}, Ljava/lang/ref/Reference;->get()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Landroid/widget/EditText;

    if-eqz v0, :cond_0

    invoke-virtual {v0, p0}, Landroid/widget/TextView;->removeTextChangedListener(Landroid/text/TextWatcher;)V

    :cond_0
    if-eqz p1, :cond_1

    .line 192
    invoke-interface {p1}, Ljava/lang/CharSequence;->length()I

    move-result v0

    iget-object v1, p0, Lcom/redmadrobot/inputmask/MaskedTextChangedListener;->afterText:Ljava/lang/String;

    const/4 v2, 0x0

    invoke-interface {p1, v2, v0, v1}, Landroid/text/Editable;->replace(IILjava/lang/CharSequence;)Landroid/text/Editable;

    .line 193
    :cond_1
    iget-object v0, p0, Lcom/redmadrobot/inputmask/MaskedTextChangedListener;->field:Ljava/lang/ref/WeakReference;

    invoke-virtual {v0}, Ljava/lang/ref/Reference;->get()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Landroid/widget/EditText;

    if-eqz v0, :cond_2

    iget v1, p0, Lcom/redmadrobot/inputmask/MaskedTextChangedListener;->caretPosition:I

    invoke-virtual {v0, v1}, Landroid/widget/EditText;->setSelection(I)V

    .line 194
    :cond_2
    iget-object v0, p0, Lcom/redmadrobot/inputmask/MaskedTextChangedListener;->field:Ljava/lang/ref/WeakReference;

    invoke-virtual {v0}, Ljava/lang/ref/Reference;->get()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Landroid/widget/EditText;

    if-eqz v0, :cond_3

    invoke-virtual {v0, p0}, Landroid/widget/TextView;->addTextChangedListener(Landroid/text/TextWatcher;)V

    .line 195
    :cond_3
    iget-object v0, p0, Lcom/redmadrobot/inputmask/MaskedTextChangedListener;->listener:Landroid/text/TextWatcher;

    if-eqz v0, :cond_4

    invoke-interface {v0, p1}, Landroid/text/TextWatcher;->afterTextChanged(Landroid/text/Editable;)V

    :cond_4
    return-void
.end method

.method public beforeTextChanged(Ljava/lang/CharSequence;III)V
    .locals 1

    .line 199
    iget-object v0, p0, Lcom/redmadrobot/inputmask/MaskedTextChangedListener;->listener:Landroid/text/TextWatcher;

    if-eqz v0, :cond_0

    invoke-interface {v0, p1, p2, p3, p4}, Landroid/text/TextWatcher;->beforeTextChanged(Ljava/lang/CharSequence;III)V

    :cond_0
    return-void
.end method

.method public final getAffineFormats()Ljava/util/List;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/List<",
            "Ljava/lang/String;",
            ">;"
        }
    .end annotation

    .line 24
    iget-object v0, p0, Lcom/redmadrobot/inputmask/MaskedTextChangedListener;->affineFormats:Ljava/util/List;

    return-object v0
.end method

.method public final getAffinityCalculationStrategy()Lcom/redmadrobot/inputmask/helper/AffinityCalculationStrategy;
    .locals 1

    .line 26
    iget-object v0, p0, Lcom/redmadrobot/inputmask/MaskedTextChangedListener;->affinityCalculationStrategy:Lcom/redmadrobot/inputmask/helper/AffinityCalculationStrategy;

    return-object v0
.end method

.method public final getAutocomplete()Z
    .locals 1

    .line 27
    iget-boolean v0, p0, Lcom/redmadrobot/inputmask/MaskedTextChangedListener;->autocomplete:Z

    return v0
.end method

.method public final getAutoskip()Z
    .locals 1

    .line 28
    iget-boolean v0, p0, Lcom/redmadrobot/inputmask/MaskedTextChangedListener;->autoskip:Z

    return v0
.end method

.method public final getCustomNotations()Ljava/util/List;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/List<",
            "Lcom/redmadrobot/inputmask/model/Notation;",
            ">;"
        }
    .end annotation

    .line 25
    iget-object v0, p0, Lcom/redmadrobot/inputmask/MaskedTextChangedListener;->customNotations:Ljava/util/List;

    return-object v0
.end method

.method public final getListener()Landroid/text/TextWatcher;
    .locals 1

    .line 30
    iget-object v0, p0, Lcom/redmadrobot/inputmask/MaskedTextChangedListener;->listener:Landroid/text/TextWatcher;

    return-object v0
.end method

.method public final getPrimaryFormat()Ljava/lang/String;
    .locals 1

    .line 23
    iget-object v0, p0, Lcom/redmadrobot/inputmask/MaskedTextChangedListener;->primaryFormat:Ljava/lang/String;

    return-object v0
.end method

.method public final getRightToLeft()Z
    .locals 1

    .line 32
    iget-boolean v0, p0, Lcom/redmadrobot/inputmask/MaskedTextChangedListener;->rightToLeft:Z

    return v0
.end method

.method public final getValueListener()Lcom/redmadrobot/inputmask/MaskedTextChangedListener$ValueListener;
    .locals 1

    .line 31
    iget-object v0, p0, Lcom/redmadrobot/inputmask/MaskedTextChangedListener;->valueListener:Lcom/redmadrobot/inputmask/MaskedTextChangedListener$ValueListener;

    return-object v0
.end method

.method public onFocusChange(Landroid/view/View;Z)V
    .locals 3

    .line 222
    iget-boolean p1, p0, Lcom/redmadrobot/inputmask/MaskedTextChangedListener;->autocomplete:Z

    if-eqz p1, :cond_6

    if-eqz p2, :cond_6

    .line 223
    iget-object p1, p0, Lcom/redmadrobot/inputmask/MaskedTextChangedListener;->field:Ljava/lang/ref/WeakReference;

    invoke-virtual {p1}, Ljava/lang/ref/Reference;->get()Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Landroid/widget/EditText;

    const/4 p2, 0x0

    if-eqz p1, :cond_0

    invoke-virtual {p1}, Landroid/widget/EditText;->getText()Landroid/text/Editable;

    move-result-object p1

    goto :goto_0

    :cond_0
    move-object p1, p2

    :goto_0
    if-nez p1, :cond_1

    invoke-static {}, Lkotlin/jvm/internal/Intrinsics;->throwNpe()V

    :cond_1
    invoke-interface {p1}, Ljava/lang/CharSequence;->length()I

    move-result p1

    if-nez p1, :cond_2

    .line 224
    const-string p1, ""

    goto :goto_1

    .line 226
    :cond_2
    iget-object p1, p0, Lcom/redmadrobot/inputmask/MaskedTextChangedListener;->field:Ljava/lang/ref/WeakReference;

    invoke-virtual {p1}, Ljava/lang/ref/Reference;->get()Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Landroid/widget/EditText;

    if-eqz p1, :cond_3

    invoke-virtual {p1}, Landroid/widget/EditText;->getText()Landroid/text/Editable;

    move-result-object p2

    :cond_3
    invoke-static {p2}, Ljava/lang/String;->valueOf(Ljava/lang/Object;)Ljava/lang/String;

    move-result-object p1

    .line 229
    :goto_1
    new-instance p2, Lcom/redmadrobot/inputmask/model/CaretString;

    invoke-virtual {p1}, Ljava/lang/String;->length()I

    move-result v0

    new-instance v1, Lcom/redmadrobot/inputmask/model/CaretString$CaretGravity$FORWARD;

    iget-boolean v2, p0, Lcom/redmadrobot/inputmask/MaskedTextChangedListener;->autocomplete:Z

    invoke-direct {v1, v2}, Lcom/redmadrobot/inputmask/model/CaretString$CaretGravity$FORWARD;-><init>(Z)V

    invoke-direct {p2, p1, v0, v1}, Lcom/redmadrobot/inputmask/model/CaretString;-><init>(Ljava/lang/String;ILcom/redmadrobot/inputmask/model/CaretString$CaretGravity;)V

    .line 232
    invoke-direct {p0, p2}, Lcom/redmadrobot/inputmask/MaskedTextChangedListener;->pickMask(Lcom/redmadrobot/inputmask/model/CaretString;)Lcom/redmadrobot/inputmask/helper/Mask;

    move-result-object p1

    invoke-virtual {p1, p2}, Lcom/redmadrobot/inputmask/helper/Mask;->apply(Lcom/redmadrobot/inputmask/model/CaretString;)Lcom/redmadrobot/inputmask/helper/Mask$Result;

    move-result-object p1

    .line 234
    invoke-virtual {p1}, Lcom/redmadrobot/inputmask/helper/Mask$Result;->getFormattedText()Lcom/redmadrobot/inputmask/model/CaretString;

    move-result-object p2

    invoke-virtual {p2}, Lcom/redmadrobot/inputmask/model/CaretString;->getString()Ljava/lang/String;

    move-result-object p2

    iput-object p2, p0, Lcom/redmadrobot/inputmask/MaskedTextChangedListener;->afterText:Ljava/lang/String;

    .line 235
    invoke-virtual {p1}, Lcom/redmadrobot/inputmask/helper/Mask$Result;->getFormattedText()Lcom/redmadrobot/inputmask/model/CaretString;

    move-result-object p2

    invoke-virtual {p2}, Lcom/redmadrobot/inputmask/model/CaretString;->getCaretPosition()I

    move-result p2

    iput p2, p0, Lcom/redmadrobot/inputmask/MaskedTextChangedListener;->caretPosition:I

    .line 236
    iget-object p2, p0, Lcom/redmadrobot/inputmask/MaskedTextChangedListener;->field:Ljava/lang/ref/WeakReference;

    invoke-virtual {p2}, Ljava/lang/ref/Reference;->get()Ljava/lang/Object;

    move-result-object p2

    check-cast p2, Landroid/widget/EditText;

    if-eqz p2, :cond_4

    iget-object v0, p0, Lcom/redmadrobot/inputmask/MaskedTextChangedListener;->afterText:Ljava/lang/String;

    invoke-virtual {p2, v0}, Landroid/widget/TextView;->setText(Ljava/lang/CharSequence;)V

    .line 237
    :cond_4
    iget-object p2, p0, Lcom/redmadrobot/inputmask/MaskedTextChangedListener;->field:Ljava/lang/ref/WeakReference;

    invoke-virtual {p2}, Ljava/lang/ref/Reference;->get()Ljava/lang/Object;

    move-result-object p2

    check-cast p2, Landroid/widget/EditText;

    if-eqz p2, :cond_5

    invoke-virtual {p1}, Lcom/redmadrobot/inputmask/helper/Mask$Result;->getFormattedText()Lcom/redmadrobot/inputmask/model/CaretString;

    move-result-object v0

    invoke-virtual {v0}, Lcom/redmadrobot/inputmask/model/CaretString;->getCaretPosition()I

    move-result v0

    invoke-virtual {p2, v0}, Landroid/widget/EditText;->setSelection(I)V

    .line 238
    :cond_5
    iget-object p2, p0, Lcom/redmadrobot/inputmask/MaskedTextChangedListener;->valueListener:Lcom/redmadrobot/inputmask/MaskedTextChangedListener$ValueListener;

    if-eqz p2, :cond_6

    invoke-virtual {p1}, Lcom/redmadrobot/inputmask/helper/Mask$Result;->getComplete()Z

    move-result v0

    invoke-virtual {p1}, Lcom/redmadrobot/inputmask/helper/Mask$Result;->getExtractedValue()Ljava/lang/String;

    move-result-object p1

    iget-object v1, p0, Lcom/redmadrobot/inputmask/MaskedTextChangedListener;->afterText:Ljava/lang/String;

    invoke-interface {p2, v0, p1, v1}, Lcom/redmadrobot/inputmask/MaskedTextChangedListener$ValueListener;->onTextChanged(ZLjava/lang/String;Ljava/lang/String;)V

    :cond_6
    return-void
.end method

.method public onTextChanged(Ljava/lang/CharSequence;III)V
    .locals 2

    const-string v0, "text"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkParameterIsNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    const/4 v0, 0x0

    if-lez p3, :cond_0

    if-nez p4, :cond_0

    const/4 p3, 0x1

    goto :goto_0

    :cond_0
    move p3, v0

    :goto_0
    if-eqz p3, :cond_1

    move v1, v0

    goto :goto_1

    .line 204
    :cond_1
    iget-boolean v1, p0, Lcom/redmadrobot/inputmask/MaskedTextChangedListener;->autocomplete:Z

    :goto_1
    if-eqz p3, :cond_2

    .line 205
    iget-boolean v0, p0, Lcom/redmadrobot/inputmask/MaskedTextChangedListener;->autoskip:Z

    :cond_2
    if-eqz p3, :cond_3

    .line 207
    new-instance v1, Lcom/redmadrobot/inputmask/model/CaretString$CaretGravity$BACKWARD;

    invoke-direct {v1, v0}, Lcom/redmadrobot/inputmask/model/CaretString$CaretGravity$BACKWARD;-><init>(Z)V

    goto :goto_2

    :cond_3
    new-instance v0, Lcom/redmadrobot/inputmask/model/CaretString$CaretGravity$FORWARD;

    invoke-direct {v0, v1}, Lcom/redmadrobot/inputmask/model/CaretString$CaretGravity$FORWARD;-><init>(Z)V

    move-object v1, v0

    :goto_2
    if-eqz p3, :cond_4

    goto :goto_3

    :cond_4
    add-int/2addr p2, p4

    .line 210
    :goto_3
    new-instance p3, Lcom/redmadrobot/inputmask/model/CaretString;

    invoke-virtual {p1}, Ljava/lang/Object;->toString()Ljava/lang/String;

    move-result-object p1

    invoke-direct {p3, p1, p2, v1}, Lcom/redmadrobot/inputmask/model/CaretString;-><init>(Ljava/lang/String;ILcom/redmadrobot/inputmask/model/CaretString$CaretGravity;)V

    .line 212
    invoke-direct {p0, p3}, Lcom/redmadrobot/inputmask/MaskedTextChangedListener;->pickMask(Lcom/redmadrobot/inputmask/model/CaretString;)Lcom/redmadrobot/inputmask/helper/Mask;

    move-result-object p1

    .line 213
    invoke-virtual {p1, p3}, Lcom/redmadrobot/inputmask/helper/Mask;->apply(Lcom/redmadrobot/inputmask/model/CaretString;)Lcom/redmadrobot/inputmask/helper/Mask$Result;

    move-result-object p1

    .line 215
    invoke-virtual {p1}, Lcom/redmadrobot/inputmask/helper/Mask$Result;->getFormattedText()Lcom/redmadrobot/inputmask/model/CaretString;

    move-result-object p2

    invoke-virtual {p2}, Lcom/redmadrobot/inputmask/model/CaretString;->getString()Ljava/lang/String;

    move-result-object p2

    iput-object p2, p0, Lcom/redmadrobot/inputmask/MaskedTextChangedListener;->afterText:Ljava/lang/String;

    .line 216
    invoke-virtual {p1}, Lcom/redmadrobot/inputmask/helper/Mask$Result;->getFormattedText()Lcom/redmadrobot/inputmask/model/CaretString;

    move-result-object p2

    invoke-virtual {p2}, Lcom/redmadrobot/inputmask/model/CaretString;->getCaretPosition()I

    move-result p2

    iput p2, p0, Lcom/redmadrobot/inputmask/MaskedTextChangedListener;->caretPosition:I

    .line 218
    iget-object p2, p0, Lcom/redmadrobot/inputmask/MaskedTextChangedListener;->valueListener:Lcom/redmadrobot/inputmask/MaskedTextChangedListener$ValueListener;

    if-eqz p2, :cond_5

    invoke-virtual {p1}, Lcom/redmadrobot/inputmask/helper/Mask$Result;->getComplete()Z

    move-result p3

    invoke-virtual {p1}, Lcom/redmadrobot/inputmask/helper/Mask$Result;->getExtractedValue()Ljava/lang/String;

    move-result-object p1

    iget-object p4, p0, Lcom/redmadrobot/inputmask/MaskedTextChangedListener;->afterText:Ljava/lang/String;

    invoke-interface {p2, p3, p1, p4}, Lcom/redmadrobot/inputmask/MaskedTextChangedListener$ValueListener;->onTextChanged(ZLjava/lang/String;Ljava/lang/String;)V

    :cond_5
    return-void
.end method

.method public final placeholder()Ljava/lang/String;
    .locals 1

    .line 160
    invoke-direct {p0}, Lcom/redmadrobot/inputmask/MaskedTextChangedListener;->getPrimaryMask()Lcom/redmadrobot/inputmask/helper/Mask;

    move-result-object v0

    invoke-virtual {v0}, Lcom/redmadrobot/inputmask/helper/Mask;->placeholder()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method public final setAffineFormats(Ljava/util/List;)V
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/util/List<",
            "Ljava/lang/String;",
            ">;)V"
        }
    .end annotation

    const-string v0, "<set-?>"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkParameterIsNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    .line 24
    iput-object p1, p0, Lcom/redmadrobot/inputmask/MaskedTextChangedListener;->affineFormats:Ljava/util/List;

    return-void
.end method

.method public final setAffinityCalculationStrategy(Lcom/redmadrobot/inputmask/helper/AffinityCalculationStrategy;)V
    .locals 1

    const-string v0, "<set-?>"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkParameterIsNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    .line 26
    iput-object p1, p0, Lcom/redmadrobot/inputmask/MaskedTextChangedListener;->affinityCalculationStrategy:Lcom/redmadrobot/inputmask/helper/AffinityCalculationStrategy;

    return-void
.end method

.method public final setAutocomplete(Z)V
    .locals 0

    .line 27
    iput-boolean p1, p0, Lcom/redmadrobot/inputmask/MaskedTextChangedListener;->autocomplete:Z

    return-void
.end method

.method public final setAutoskip(Z)V
    .locals 0

    .line 28
    iput-boolean p1, p0, Lcom/redmadrobot/inputmask/MaskedTextChangedListener;->autoskip:Z

    return-void
.end method

.method public final setCustomNotations(Ljava/util/List;)V
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/util/List<",
            "Lcom/redmadrobot/inputmask/model/Notation;",
            ">;)V"
        }
    .end annotation

    const-string v0, "<set-?>"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkParameterIsNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    .line 25
    iput-object p1, p0, Lcom/redmadrobot/inputmask/MaskedTextChangedListener;->customNotations:Ljava/util/List;

    return-void
.end method

.method public final setListener(Landroid/text/TextWatcher;)V
    .locals 0

    .line 30
    iput-object p1, p0, Lcom/redmadrobot/inputmask/MaskedTextChangedListener;->listener:Landroid/text/TextWatcher;

    return-void
.end method

.method public final setPrimaryFormat(Ljava/lang/String;)V
    .locals 1

    const-string v0, "<set-?>"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkParameterIsNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    .line 23
    iput-object p1, p0, Lcom/redmadrobot/inputmask/MaskedTextChangedListener;->primaryFormat:Ljava/lang/String;

    return-void
.end method

.method public final setRightToLeft(Z)V
    .locals 0

    .line 32
    iput-boolean p1, p0, Lcom/redmadrobot/inputmask/MaskedTextChangedListener;->rightToLeft:Z

    return-void
.end method

.method public setText(Ljava/lang/String;Landroid/widget/EditText;Ljava/lang/Boolean;)Lcom/redmadrobot/inputmask/helper/Mask$Result;
    .locals 3

    const-string v0, "text"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkParameterIsNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "field"

    invoke-static {p2, v0}, Lkotlin/jvm/internal/Intrinsics;->checkParameterIsNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    if-eqz p3, :cond_0

    .line 143
    invoke-virtual {p3}, Ljava/lang/Boolean;->booleanValue()Z

    move-result p3

    goto :goto_0

    :cond_0
    iget-boolean p3, p0, Lcom/redmadrobot/inputmask/MaskedTextChangedListener;->autocomplete:Z

    .line 144
    :goto_0
    new-instance v0, Lcom/redmadrobot/inputmask/model/CaretString;

    invoke-virtual {p1}, Ljava/lang/String;->length()I

    move-result v1

    new-instance v2, Lcom/redmadrobot/inputmask/model/CaretString$CaretGravity$FORWARD;

    invoke-direct {v2, p3}, Lcom/redmadrobot/inputmask/model/CaretString$CaretGravity$FORWARD;-><init>(Z)V

    invoke-direct {v0, p1, v1, v2}, Lcom/redmadrobot/inputmask/model/CaretString;-><init>(Ljava/lang/String;ILcom/redmadrobot/inputmask/model/CaretString$CaretGravity;)V

    .line 145
    invoke-direct {p0, v0}, Lcom/redmadrobot/inputmask/MaskedTextChangedListener;->pickMask(Lcom/redmadrobot/inputmask/model/CaretString;)Lcom/redmadrobot/inputmask/helper/Mask;

    move-result-object p1

    invoke-virtual {p1, v0}, Lcom/redmadrobot/inputmask/helper/Mask;->apply(Lcom/redmadrobot/inputmask/model/CaretString;)Lcom/redmadrobot/inputmask/helper/Mask$Result;

    move-result-object p1

    .line 148
    invoke-virtual {p1}, Lcom/redmadrobot/inputmask/helper/Mask$Result;->getFormattedText()Lcom/redmadrobot/inputmask/model/CaretString;

    move-result-object p3

    invoke-virtual {p3}, Lcom/redmadrobot/inputmask/model/CaretString;->getString()Ljava/lang/String;

    move-result-object p3

    invoke-virtual {p2, p3}, Landroid/widget/TextView;->setText(Ljava/lang/CharSequence;)V

    .line 149
    invoke-virtual {p1}, Lcom/redmadrobot/inputmask/helper/Mask$Result;->getFormattedText()Lcom/redmadrobot/inputmask/model/CaretString;

    move-result-object p3

    invoke-virtual {p3}, Lcom/redmadrobot/inputmask/model/CaretString;->getCaretPosition()I

    move-result p3

    invoke-virtual {p2, p3}, Landroid/widget/EditText;->setSelection(I)V

    return-object p1
.end method

.method public setText(Ljava/lang/String;Ljava/lang/Boolean;)Lcom/redmadrobot/inputmask/helper/Mask$Result;
    .locals 3

    const-string v0, "text"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkParameterIsNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    .line 128
    iget-object v0, p0, Lcom/redmadrobot/inputmask/MaskedTextChangedListener;->field:Ljava/lang/ref/WeakReference;

    invoke-virtual {v0}, Ljava/lang/ref/Reference;->get()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Landroid/widget/EditText;

    if-eqz v0, :cond_1

    .line 129
    const-string v1, "it"

    invoke-static {v0, v1}, Lkotlin/jvm/internal/Intrinsics;->checkExpressionValueIsNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-virtual {p0, p1, v0, p2}, Lcom/redmadrobot/inputmask/MaskedTextChangedListener;->setText(Ljava/lang/String;Landroid/widget/EditText;Ljava/lang/Boolean;)Lcom/redmadrobot/inputmask/helper/Mask$Result;

    move-result-object p1

    .line 130
    invoke-virtual {p1}, Lcom/redmadrobot/inputmask/helper/Mask$Result;->getFormattedText()Lcom/redmadrobot/inputmask/model/CaretString;

    move-result-object p2

    invoke-virtual {p2}, Lcom/redmadrobot/inputmask/model/CaretString;->getString()Ljava/lang/String;

    move-result-object p2

    iput-object p2, p0, Lcom/redmadrobot/inputmask/MaskedTextChangedListener;->afterText:Ljava/lang/String;

    .line 131
    invoke-virtual {p1}, Lcom/redmadrobot/inputmask/helper/Mask$Result;->getFormattedText()Lcom/redmadrobot/inputmask/model/CaretString;

    move-result-object p2

    invoke-virtual {p2}, Lcom/redmadrobot/inputmask/model/CaretString;->getCaretPosition()I

    move-result p2

    iput p2, p0, Lcom/redmadrobot/inputmask/MaskedTextChangedListener;->caretPosition:I

    .line 132
    iget-object p2, p0, Lcom/redmadrobot/inputmask/MaskedTextChangedListener;->valueListener:Lcom/redmadrobot/inputmask/MaskedTextChangedListener$ValueListener;

    if-eqz p2, :cond_0

    invoke-virtual {p1}, Lcom/redmadrobot/inputmask/helper/Mask$Result;->getComplete()Z

    move-result v0

    invoke-virtual {p1}, Lcom/redmadrobot/inputmask/helper/Mask$Result;->getExtractedValue()Ljava/lang/String;

    move-result-object v1

    iget-object v2, p0, Lcom/redmadrobot/inputmask/MaskedTextChangedListener;->afterText:Ljava/lang/String;

    invoke-interface {p2, v0, v1, v2}, Lcom/redmadrobot/inputmask/MaskedTextChangedListener$ValueListener;->onTextChanged(ZLjava/lang/String;Ljava/lang/String;)V

    :cond_0
    return-object p1

    :cond_1
    const/4 p1, 0x0

    return-object p1
.end method

.method public final setValueListener(Lcom/redmadrobot/inputmask/MaskedTextChangedListener$ValueListener;)V
    .locals 0

    .line 31
    iput-object p1, p0, Lcom/redmadrobot/inputmask/MaskedTextChangedListener;->valueListener:Lcom/redmadrobot/inputmask/MaskedTextChangedListener$ValueListener;

    return-void
.end method

.method public final totalTextLength()I
    .locals 1

    .line 174
    invoke-direct {p0}, Lcom/redmadrobot/inputmask/MaskedTextChangedListener;->getPrimaryMask()Lcom/redmadrobot/inputmask/helper/Mask;

    move-result-object v0

    invoke-virtual {v0}, Lcom/redmadrobot/inputmask/helper/Mask;->totalTextLength()I

    move-result v0

    return v0
.end method

.method public final totalValueLength()I
    .locals 1

    .line 188
    invoke-direct {p0}, Lcom/redmadrobot/inputmask/MaskedTextChangedListener;->getPrimaryMask()Lcom/redmadrobot/inputmask/helper/Mask;

    move-result-object v0

    invoke-virtual {v0}, Lcom/redmadrobot/inputmask/helper/Mask;->totalValueLength()I

    move-result v0

    return v0
.end method
