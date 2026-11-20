.class public final Lcom/redmadrobot/inputmask/MaskedTextChangedListener$Companion;
.super Ljava/lang/Object;
.source "MaskedTextChangedListener.kt"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/redmadrobot/inputmask/MaskedTextChangedListener;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x19
    name = "Companion"
.end annotation


# direct methods
.method private constructor <init>()V
    .locals 0

    .line 295
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method

.method public synthetic constructor <init>(Lkotlin/jvm/internal/DefaultConstructorMarker;)V
    .locals 0

    .line 295
    invoke-direct {p0}, Lcom/redmadrobot/inputmask/MaskedTextChangedListener$Companion;-><init>()V

    return-void
.end method

.method public static synthetic installOn$default(Lcom/redmadrobot/inputmask/MaskedTextChangedListener$Companion;Landroid/widget/EditText;Ljava/lang/String;Lcom/redmadrobot/inputmask/MaskedTextChangedListener$ValueListener;ILjava/lang/Object;)Lcom/redmadrobot/inputmask/MaskedTextChangedListener;
    .locals 0

    and-int/lit8 p4, p4, 0x4

    if-eqz p4, :cond_0

    const/4 p3, 0x0

    .line 303
    :cond_0
    invoke-virtual {p0, p1, p2, p3}, Lcom/redmadrobot/inputmask/MaskedTextChangedListener$Companion;->installOn(Landroid/widget/EditText;Ljava/lang/String;Lcom/redmadrobot/inputmask/MaskedTextChangedListener$ValueListener;)Lcom/redmadrobot/inputmask/MaskedTextChangedListener;

    move-result-object p0

    return-object p0
.end method

.method public static synthetic installOn$default(Lcom/redmadrobot/inputmask/MaskedTextChangedListener$Companion;Landroid/widget/EditText;Ljava/lang/String;Ljava/util/List;Lcom/redmadrobot/inputmask/helper/AffinityCalculationStrategy;Lcom/redmadrobot/inputmask/MaskedTextChangedListener$ValueListener;ILjava/lang/Object;)Lcom/redmadrobot/inputmask/MaskedTextChangedListener;
    .locals 6

    and-int/lit8 p7, p6, 0x4

    if-eqz p7, :cond_0

    .line 319
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/CollectionsKt;->emptyList()Ljava/util/List;

    move-result-object p3

    :cond_0
    move-object v3, p3

    and-int/lit8 p3, p6, 0x8

    if-eqz p3, :cond_1

    .line 320
    sget-object p4, Lcom/redmadrobot/inputmask/helper/AffinityCalculationStrategy;->WHOLE_STRING:Lcom/redmadrobot/inputmask/helper/AffinityCalculationStrategy;

    :cond_1
    move-object v4, p4

    and-int/lit8 p3, p6, 0x10

    if-eqz p3, :cond_2

    const/4 p5, 0x0

    :cond_2
    move-object v0, p0

    move-object v1, p1

    move-object v2, p2

    move-object v5, p5

    .line 321
    invoke-virtual/range {v0 .. v5}, Lcom/redmadrobot/inputmask/MaskedTextChangedListener$Companion;->installOn(Landroid/widget/EditText;Ljava/lang/String;Ljava/util/List;Lcom/redmadrobot/inputmask/helper/AffinityCalculationStrategy;Lcom/redmadrobot/inputmask/MaskedTextChangedListener$ValueListener;)Lcom/redmadrobot/inputmask/MaskedTextChangedListener;

    move-result-object p0

    return-object p0
.end method

.method public static synthetic installOn$default(Lcom/redmadrobot/inputmask/MaskedTextChangedListener$Companion;Landroid/widget/EditText;Ljava/lang/String;Ljava/util/List;Ljava/util/List;Lcom/redmadrobot/inputmask/helper/AffinityCalculationStrategy;ZZLandroid/text/TextWatcher;Lcom/redmadrobot/inputmask/MaskedTextChangedListener$ValueListener;ILjava/lang/Object;)Lcom/redmadrobot/inputmask/MaskedTextChangedListener;
    .locals 10

    move/from16 v0, p10

    and-int/lit8 v1, v0, 0x4

    if-eqz v1, :cond_0

    .line 341
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/CollectionsKt;->emptyList()Ljava/util/List;

    move-result-object p3

    :cond_0
    move-object v3, p3

    and-int/lit8 p3, v0, 0x8

    if-eqz p3, :cond_1

    .line 342
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/CollectionsKt;->emptyList()Ljava/util/List;

    move-result-object p3

    move-object v4, p3

    goto :goto_0

    :cond_1
    move-object v4, p4

    :goto_0
    and-int/lit8 p3, v0, 0x10

    if-eqz p3, :cond_2

    .line 343
    sget-object p3, Lcom/redmadrobot/inputmask/helper/AffinityCalculationStrategy;->WHOLE_STRING:Lcom/redmadrobot/inputmask/helper/AffinityCalculationStrategy;

    move-object v5, p3

    goto :goto_1

    :cond_2
    move-object v5, p5

    :goto_1
    and-int/lit8 p3, v0, 0x20

    if-eqz p3, :cond_3

    const/4 p3, 0x1

    move v6, p3

    goto :goto_2

    :cond_3
    move/from16 v6, p6

    :goto_2
    and-int/lit8 p3, v0, 0x40

    if-eqz p3, :cond_4

    const/4 p3, 0x0

    move v7, p3

    goto :goto_3

    :cond_4
    move/from16 v7, p7

    :goto_3
    and-int/lit16 p3, v0, 0x80

    const/4 v1, 0x0

    if-eqz p3, :cond_5

    move-object v8, v1

    goto :goto_4

    :cond_5
    move-object/from16 v8, p8

    :goto_4
    and-int/lit16 p3, v0, 0x100

    if-eqz p3, :cond_6

    move-object v9, v1

    move-object v0, p0

    move-object v2, p2

    move-object v1, p1

    goto :goto_5

    :cond_6
    move-object/from16 v9, p9

    move-object v0, p0

    move-object v1, p1

    move-object v2, p2

    .line 347
    :goto_5
    invoke-virtual/range {v0 .. v9}, Lcom/redmadrobot/inputmask/MaskedTextChangedListener$Companion;->installOn(Landroid/widget/EditText;Ljava/lang/String;Ljava/util/List;Ljava/util/List;Lcom/redmadrobot/inputmask/helper/AffinityCalculationStrategy;ZZLandroid/text/TextWatcher;Lcom/redmadrobot/inputmask/MaskedTextChangedListener$ValueListener;)Lcom/redmadrobot/inputmask/MaskedTextChangedListener;

    move-result-object p0

    return-object p0
.end method


# virtual methods
.method public final installOn(Landroid/widget/EditText;Ljava/lang/String;Lcom/redmadrobot/inputmask/MaskedTextChangedListener$ValueListener;)Lcom/redmadrobot/inputmask/MaskedTextChangedListener;
    .locals 7

    const-string v0, "editText"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkParameterIsNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "primaryFormat"

    invoke-static {p2, v0}, Lkotlin/jvm/internal/Intrinsics;->checkParameterIsNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    .line 307
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/CollectionsKt;->emptyList()Ljava/util/List;

    move-result-object v4

    .line 308
    sget-object v5, Lcom/redmadrobot/inputmask/helper/AffinityCalculationStrategy;->WHOLE_STRING:Lcom/redmadrobot/inputmask/helper/AffinityCalculationStrategy;

    move-object v1, p0

    move-object v2, p1

    move-object v3, p2

    move-object v6, p3

    .line 304
    invoke-virtual/range {v1 .. v6}, Lcom/redmadrobot/inputmask/MaskedTextChangedListener$Companion;->installOn(Landroid/widget/EditText;Ljava/lang/String;Ljava/util/List;Lcom/redmadrobot/inputmask/helper/AffinityCalculationStrategy;Lcom/redmadrobot/inputmask/MaskedTextChangedListener$ValueListener;)Lcom/redmadrobot/inputmask/MaskedTextChangedListener;

    move-result-object p1

    return-object p1
.end method

.method public final installOn(Landroid/widget/EditText;Ljava/lang/String;Ljava/util/List;Lcom/redmadrobot/inputmask/helper/AffinityCalculationStrategy;Lcom/redmadrobot/inputmask/MaskedTextChangedListener$ValueListener;)Lcom/redmadrobot/inputmask/MaskedTextChangedListener;
    .locals 11
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Landroid/widget/EditText;",
            "Ljava/lang/String;",
            "Ljava/util/List<",
            "Ljava/lang/String;",
            ">;",
            "Lcom/redmadrobot/inputmask/helper/AffinityCalculationStrategy;",
            "Lcom/redmadrobot/inputmask/MaskedTextChangedListener$ValueListener;",
            ")",
            "Lcom/redmadrobot/inputmask/MaskedTextChangedListener;"
        }
    .end annotation

    const-string v0, "editText"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkParameterIsNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "primaryFormat"

    invoke-static {p2, v0}, Lkotlin/jvm/internal/Intrinsics;->checkParameterIsNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "affineFormats"

    invoke-static {p3, v0}, Lkotlin/jvm/internal/Intrinsics;->checkParameterIsNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "affinityCalculationStrategy"

    invoke-static {p4, v0}, Lkotlin/jvm/internal/Intrinsics;->checkParameterIsNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    .line 326
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/CollectionsKt;->emptyList()Ljava/util/List;

    move-result-object v5

    const/4 v8, 0x0

    const/4 v9, 0x0

    const/4 v7, 0x1

    move-object v1, p0

    move-object v2, p1

    move-object v3, p2

    move-object v4, p3

    move-object v6, p4

    move-object/from16 v10, p5

    .line 322
    invoke-virtual/range {v1 .. v10}, Lcom/redmadrobot/inputmask/MaskedTextChangedListener$Companion;->installOn(Landroid/widget/EditText;Ljava/lang/String;Ljava/util/List;Ljava/util/List;Lcom/redmadrobot/inputmask/helper/AffinityCalculationStrategy;ZZLandroid/text/TextWatcher;Lcom/redmadrobot/inputmask/MaskedTextChangedListener$ValueListener;)Lcom/redmadrobot/inputmask/MaskedTextChangedListener;

    move-result-object p1

    return-object p1
.end method

.method public final installOn(Landroid/widget/EditText;Ljava/lang/String;Ljava/util/List;Ljava/util/List;Lcom/redmadrobot/inputmask/helper/AffinityCalculationStrategy;ZZLandroid/text/TextWatcher;Lcom/redmadrobot/inputmask/MaskedTextChangedListener$ValueListener;)Lcom/redmadrobot/inputmask/MaskedTextChangedListener;
    .locals 13
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Landroid/widget/EditText;",
            "Ljava/lang/String;",
            "Ljava/util/List<",
            "Ljava/lang/String;",
            ">;",
            "Ljava/util/List<",
            "Lcom/redmadrobot/inputmask/model/Notation;",
            ">;",
            "Lcom/redmadrobot/inputmask/helper/AffinityCalculationStrategy;",
            "ZZ",
            "Landroid/text/TextWatcher;",
            "Lcom/redmadrobot/inputmask/MaskedTextChangedListener$ValueListener;",
            ")",
            "Lcom/redmadrobot/inputmask/MaskedTextChangedListener;"
        }
    .end annotation

    const-string v0, "editText"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkParameterIsNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "primaryFormat"

    invoke-static {p2, v0}, Lkotlin/jvm/internal/Intrinsics;->checkParameterIsNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "affineFormats"

    move-object/from16 v2, p3

    invoke-static {v2, v0}, Lkotlin/jvm/internal/Intrinsics;->checkParameterIsNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "customNotations"

    move-object/from16 v3, p4

    invoke-static {v3, v0}, Lkotlin/jvm/internal/Intrinsics;->checkParameterIsNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "affinityCalculationStrategy"

    move-object/from16 v4, p5

    invoke-static {v4, v0}, Lkotlin/jvm/internal/Intrinsics;->checkParameterIsNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    .line 349
    new-instance v0, Lcom/redmadrobot/inputmask/MaskedTextChangedListener;

    const/16 v11, 0x200

    const/4 v12, 0x0

    const/4 v10, 0x0

    move-object v7, p1

    move-object v1, p2

    move/from16 v5, p6

    move/from16 v6, p7

    move-object/from16 v8, p8

    move-object/from16 v9, p9

    invoke-direct/range {v0 .. v12}, Lcom/redmadrobot/inputmask/MaskedTextChangedListener;-><init>(Ljava/lang/String;Ljava/util/List;Ljava/util/List;Lcom/redmadrobot/inputmask/helper/AffinityCalculationStrategy;ZZLandroid/widget/EditText;Landroid/text/TextWatcher;Lcom/redmadrobot/inputmask/MaskedTextChangedListener$ValueListener;ZILkotlin/jvm/internal/DefaultConstructorMarker;)V

    .line 360
    invoke-virtual {p1, v0}, Landroid/widget/TextView;->addTextChangedListener(Landroid/text/TextWatcher;)V

    .line 361
    invoke-virtual {p1, v0}, Landroid/view/View;->setOnFocusChangeListener(Landroid/view/View$OnFocusChangeListener;)V

    return-object v0
.end method
