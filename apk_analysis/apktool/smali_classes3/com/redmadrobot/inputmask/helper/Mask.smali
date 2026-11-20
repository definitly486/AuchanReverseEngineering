.class public Lcom/redmadrobot/inputmask/helper/Mask;
.super Ljava/lang/Object;
.source "Mask.kt"


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/redmadrobot/inputmask/helper/Mask$Result;,
        Lcom/redmadrobot/inputmask/helper/Mask$AutocompletionStack;,
        Lcom/redmadrobot/inputmask/helper/Mask$Factory;
    }
.end annotation


# static fields
.field public static final Factory:Lcom/redmadrobot/inputmask/helper/Mask$Factory;

.field private static final cache:Ljava/util/Map;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/util/Map<",
            "Ljava/lang/String;",
            "Lcom/redmadrobot/inputmask/helper/Mask;",
            ">;"
        }
    .end annotation
.end field


# instance fields
.field private final customNotations:Ljava/util/List;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/util/List<",
            "Lcom/redmadrobot/inputmask/model/Notation;",
            ">;"
        }
    .end annotation
.end field

.field private final initialState:Lcom/redmadrobot/inputmask/model/State;


# direct methods
.method static constructor <clinit>()V
    .locals 2

    new-instance v0, Lcom/redmadrobot/inputmask/helper/Mask$Factory;

    const/4 v1, 0x0

    invoke-direct {v0, v1}, Lcom/redmadrobot/inputmask/helper/Mask$Factory;-><init>(Lkotlin/jvm/internal/DefaultConstructorMarker;)V

    sput-object v0, Lcom/redmadrobot/inputmask/helper/Mask;->Factory:Lcom/redmadrobot/inputmask/helper/Mask$Factory;

    .line 63
    new-instance v0, Ljava/util/HashMap;

    invoke-direct {v0}, Ljava/util/HashMap;-><init>()V

    sput-object v0, Lcom/redmadrobot/inputmask/helper/Mask;->cache:Ljava/util/Map;

    return-void
.end method

.method public constructor <init>(Ljava/lang/String;)V
    .locals 1

    const-string v0, "format"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkParameterIsNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    .line 28
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/CollectionsKt;->emptyList()Ljava/util/List;

    move-result-object v0

    invoke-direct {p0, p1, v0}, Lcom/redmadrobot/inputmask/helper/Mask;-><init>(Ljava/lang/String;Ljava/util/List;)V

    return-void
.end method

.method public constructor <init>(Ljava/lang/String;Ljava/util/List;)V
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/lang/String;",
            "Ljava/util/List<",
            "Lcom/redmadrobot/inputmask/model/Notation;",
            ">;)V"
        }
    .end annotation

    const-string v0, "format"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkParameterIsNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "customNotations"

    invoke-static {p2, v0}, Lkotlin/jvm/internal/Intrinsics;->checkParameterIsNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    .line 23
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput-object p2, p0, Lcom/redmadrobot/inputmask/helper/Mask;->customNotations:Ljava/util/List;

    .line 103
    new-instance v0, Lcom/redmadrobot/inputmask/helper/Compiler;

    invoke-direct {v0, p2}, Lcom/redmadrobot/inputmask/helper/Compiler;-><init>(Ljava/util/List;)V

    invoke-virtual {v0, p1}, Lcom/redmadrobot/inputmask/helper/Compiler;->compile(Ljava/lang/String;)Lcom/redmadrobot/inputmask/model/State;

    move-result-object p1

    iput-object p1, p0, Lcom/redmadrobot/inputmask/helper/Mask;->initialState:Lcom/redmadrobot/inputmask/model/State;

    return-void
.end method

.method public static final synthetic access$getCache$cp()Ljava/util/Map;
    .locals 1

    .line 23
    sget-object v0, Lcom/redmadrobot/inputmask/helper/Mask;->cache:Ljava/util/Map;

    return-object v0
.end method

.method private final appendPlaceholder(Lcom/redmadrobot/inputmask/model/State;Ljava/lang/String;)Ljava/lang/String;
    .locals 6

    if-nez p1, :cond_0

    goto/16 :goto_0

    .line 285
    :cond_0
    instance-of v0, p1, Lcom/redmadrobot/inputmask/model/state/EOLState;

    if-eqz v0, :cond_1

    return-object p2

    .line 289
    :cond_1
    instance-of v0, p1, Lcom/redmadrobot/inputmask/model/state/FixedState;

    if-eqz v0, :cond_2

    .line 290
    invoke-virtual {p1}, Lcom/redmadrobot/inputmask/model/State;->getChild()Lcom/redmadrobot/inputmask/model/State;

    move-result-object v0

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v1, p2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    check-cast p1, Lcom/redmadrobot/inputmask/model/state/FixedState;

    invoke-virtual {p1}, Lcom/redmadrobot/inputmask/model/state/FixedState;->getOwnCharacter()C

    move-result p1

    invoke-virtual {v1, p1}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p1

    invoke-direct {p0, v0, p1}, Lcom/redmadrobot/inputmask/helper/Mask;->appendPlaceholder(Lcom/redmadrobot/inputmask/model/State;Ljava/lang/String;)Ljava/lang/String;

    move-result-object p1

    return-object p1

    .line 293
    :cond_2
    instance-of v0, p1, Lcom/redmadrobot/inputmask/model/state/FreeState;

    if-eqz v0, :cond_3

    .line 294
    invoke-virtual {p1}, Lcom/redmadrobot/inputmask/model/State;->getChild()Lcom/redmadrobot/inputmask/model/State;

    move-result-object v0

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v1, p2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    check-cast p1, Lcom/redmadrobot/inputmask/model/state/FreeState;

    invoke-virtual {p1}, Lcom/redmadrobot/inputmask/model/state/FreeState;->getOwnCharacter()C

    move-result p1

    invoke-virtual {v1, p1}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p1

    invoke-direct {p0, v0, p1}, Lcom/redmadrobot/inputmask/helper/Mask;->appendPlaceholder(Lcom/redmadrobot/inputmask/model/State;Ljava/lang/String;)Ljava/lang/String;

    move-result-object p1

    return-object p1

    .line 297
    :cond_3
    instance-of v0, p1, Lcom/redmadrobot/inputmask/model/state/OptionalValueState;

    const-string v1, "0"

    const-string v2, "a"

    const-string v3, "-"

    if-eqz v0, :cond_8

    .line 298
    move-object v0, p1

    check-cast v0, Lcom/redmadrobot/inputmask/model/state/OptionalValueState;

    invoke-virtual {v0}, Lcom/redmadrobot/inputmask/model/state/OptionalValueState;->getType()Lcom/redmadrobot/inputmask/model/state/OptionalValueState$StateType;

    move-result-object v4

    .line 299
    instance-of v5, v4, Lcom/redmadrobot/inputmask/model/state/OptionalValueState$StateType$AlphaNumeric;

    if-eqz v5, :cond_4

    .line 300
    invoke-virtual {p1}, Lcom/redmadrobot/inputmask/model/State;->getChild()Lcom/redmadrobot/inputmask/model/State;

    move-result-object p1

    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v0, p2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v0, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p2

    invoke-direct {p0, p1, p2}, Lcom/redmadrobot/inputmask/helper/Mask;->appendPlaceholder(Lcom/redmadrobot/inputmask/model/State;Ljava/lang/String;)Ljava/lang/String;

    move-result-object p1

    return-object p1

    .line 303
    :cond_4
    instance-of v3, v4, Lcom/redmadrobot/inputmask/model/state/OptionalValueState$StateType$Literal;

    if-eqz v3, :cond_5

    .line 304
    invoke-virtual {p1}, Lcom/redmadrobot/inputmask/model/State;->getChild()Lcom/redmadrobot/inputmask/model/State;

    move-result-object p1

    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v0, p2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v0, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p2

    invoke-direct {p0, p1, p2}, Lcom/redmadrobot/inputmask/helper/Mask;->appendPlaceholder(Lcom/redmadrobot/inputmask/model/State;Ljava/lang/String;)Ljava/lang/String;

    move-result-object p1

    return-object p1

    .line 307
    :cond_5
    instance-of v2, v4, Lcom/redmadrobot/inputmask/model/state/OptionalValueState$StateType$Numeric;

    if-eqz v2, :cond_6

    .line 308
    invoke-virtual {p1}, Lcom/redmadrobot/inputmask/model/State;->getChild()Lcom/redmadrobot/inputmask/model/State;

    move-result-object p1

    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v0, p2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p2

    invoke-direct {p0, p1, p2}, Lcom/redmadrobot/inputmask/helper/Mask;->appendPlaceholder(Lcom/redmadrobot/inputmask/model/State;Ljava/lang/String;)Ljava/lang/String;

    move-result-object p1

    return-object p1

    .line 311
    :cond_6
    instance-of v1, v4, Lcom/redmadrobot/inputmask/model/state/OptionalValueState$StateType$Custom;

    if-eqz v1, :cond_7

    .line 312
    invoke-virtual {p1}, Lcom/redmadrobot/inputmask/model/State;->getChild()Lcom/redmadrobot/inputmask/model/State;

    move-result-object p1

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v1, p2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v0}, Lcom/redmadrobot/inputmask/model/state/OptionalValueState;->getType()Lcom/redmadrobot/inputmask/model/state/OptionalValueState$StateType;

    move-result-object p2

    check-cast p2, Lcom/redmadrobot/inputmask/model/state/OptionalValueState$StateType$Custom;

    invoke-virtual {p2}, Lcom/redmadrobot/inputmask/model/state/OptionalValueState$StateType$Custom;->getCharacter()C

    move-result p2

    invoke-virtual {v1, p2}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p2

    invoke-direct {p0, p1, p2}, Lcom/redmadrobot/inputmask/helper/Mask;->appendPlaceholder(Lcom/redmadrobot/inputmask/model/State;Ljava/lang/String;)Ljava/lang/String;

    move-result-object p1

    return-object p1

    :cond_7
    new-instance p1, Lcom/scanflow/datacapture/barinternal/kotlin/NoWhenBranchMatchedException;

    invoke-direct {p1}, Lcom/scanflow/datacapture/barinternal/kotlin/NoWhenBranchMatchedException;-><init>()V

    throw p1

    .line 317
    :cond_8
    instance-of v0, p1, Lcom/redmadrobot/inputmask/model/state/ValueState;

    if-eqz v0, :cond_e

    .line 318
    move-object v0, p1

    check-cast v0, Lcom/redmadrobot/inputmask/model/state/ValueState;

    invoke-virtual {v0}, Lcom/redmadrobot/inputmask/model/state/ValueState;->getType()Lcom/redmadrobot/inputmask/model/state/ValueState$StateType;

    move-result-object v4

    .line 319
    instance-of v5, v4, Lcom/redmadrobot/inputmask/model/state/ValueState$StateType$AlphaNumeric;

    if-eqz v5, :cond_9

    .line 320
    invoke-virtual {p1}, Lcom/redmadrobot/inputmask/model/State;->getChild()Lcom/redmadrobot/inputmask/model/State;

    move-result-object p1

    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v0, p2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v0, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p2

    invoke-direct {p0, p1, p2}, Lcom/redmadrobot/inputmask/helper/Mask;->appendPlaceholder(Lcom/redmadrobot/inputmask/model/State;Ljava/lang/String;)Ljava/lang/String;

    move-result-object p1

    return-object p1

    .line 323
    :cond_9
    instance-of v3, v4, Lcom/redmadrobot/inputmask/model/state/ValueState$StateType$Literal;

    if-eqz v3, :cond_a

    .line 324
    invoke-virtual {p1}, Lcom/redmadrobot/inputmask/model/State;->getChild()Lcom/redmadrobot/inputmask/model/State;

    move-result-object p1

    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v0, p2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v0, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p2

    invoke-direct {p0, p1, p2}, Lcom/redmadrobot/inputmask/helper/Mask;->appendPlaceholder(Lcom/redmadrobot/inputmask/model/State;Ljava/lang/String;)Ljava/lang/String;

    move-result-object p1

    return-object p1

    .line 327
    :cond_a
    instance-of v2, v4, Lcom/redmadrobot/inputmask/model/state/ValueState$StateType$Numeric;

    if-eqz v2, :cond_b

    .line 328
    invoke-virtual {p1}, Lcom/redmadrobot/inputmask/model/State;->getChild()Lcom/redmadrobot/inputmask/model/State;

    move-result-object p1

    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v0, p2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p2

    invoke-direct {p0, p1, p2}, Lcom/redmadrobot/inputmask/helper/Mask;->appendPlaceholder(Lcom/redmadrobot/inputmask/model/State;Ljava/lang/String;)Ljava/lang/String;

    move-result-object p1

    return-object p1

    .line 331
    :cond_b
    instance-of v1, v4, Lcom/redmadrobot/inputmask/model/state/ValueState$StateType$Ellipsis;

    if-eqz v1, :cond_c

    goto :goto_0

    .line 333
    :cond_c
    instance-of v1, v4, Lcom/redmadrobot/inputmask/model/state/ValueState$StateType$Custom;

    if-eqz v1, :cond_d

    .line 334
    invoke-virtual {p1}, Lcom/redmadrobot/inputmask/model/State;->getChild()Lcom/redmadrobot/inputmask/model/State;

    move-result-object p1

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v1, p2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v0}, Lcom/redmadrobot/inputmask/model/state/ValueState;->getType()Lcom/redmadrobot/inputmask/model/state/ValueState$StateType;

    move-result-object p2

    check-cast p2, Lcom/redmadrobot/inputmask/model/state/ValueState$StateType$Custom;

    invoke-virtual {p2}, Lcom/redmadrobot/inputmask/model/state/ValueState$StateType$Custom;->getCharacter()C

    move-result p2

    invoke-virtual {v1, p2}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p2

    invoke-direct {p0, p1, p2}, Lcom/redmadrobot/inputmask/helper/Mask;->appendPlaceholder(Lcom/redmadrobot/inputmask/model/State;Ljava/lang/String;)Ljava/lang/String;

    move-result-object p1

    return-object p1

    :cond_d
    new-instance p1, Lcom/scanflow/datacapture/barinternal/kotlin/NoWhenBranchMatchedException;

    invoke-direct {p1}, Lcom/scanflow/datacapture/barinternal/kotlin/NoWhenBranchMatchedException;-><init>()V

    throw p1

    :cond_e
    :goto_0
    return-object p2
.end method

.method private final noMandatoryCharactersLeftAfterState(Lcom/redmadrobot/inputmask/model/State;)Z
    .locals 1

    .line 344
    instance-of v0, p1, Lcom/redmadrobot/inputmask/model/state/EOLState;

    if-eqz v0, :cond_0

    const/4 p1, 0x1

    return p1

    .line 345
    :cond_0
    instance-of v0, p1, Lcom/redmadrobot/inputmask/model/state/ValueState;

    if-eqz v0, :cond_1

    check-cast p1, Lcom/redmadrobot/inputmask/model/state/ValueState;

    invoke-virtual {p1}, Lcom/redmadrobot/inputmask/model/state/ValueState;->isElliptical()Z

    move-result p1

    return p1

    .line 346
    :cond_1
    instance-of v0, p1, Lcom/redmadrobot/inputmask/model/state/FixedState;

    if-eqz v0, :cond_2

    const/4 p1, 0x0

    return p1

    .line 347
    :cond_2
    invoke-virtual {p1}, Lcom/redmadrobot/inputmask/model/State;->nextState()Lcom/redmadrobot/inputmask/model/State;

    move-result-object p1

    invoke-direct {p0, p1}, Lcom/redmadrobot/inputmask/helper/Mask;->noMandatoryCharactersLeftAfterState(Lcom/redmadrobot/inputmask/model/State;)Z

    move-result p1

    return p1
.end method


# virtual methods
.method public final acceptableTextLength()I
    .locals 3

    .line 210
    iget-object v0, p0, Lcom/redmadrobot/inputmask/helper/Mask;->initialState:Lcom/redmadrobot/inputmask/model/State;

    const/4 v1, 0x0

    :goto_0
    if-eqz v0, :cond_2

    .line 213
    instance-of v2, v0, Lcom/redmadrobot/inputmask/model/state/EOLState;

    if-nez v2, :cond_2

    .line 214
    instance-of v2, v0, Lcom/redmadrobot/inputmask/model/state/FixedState;

    if-nez v2, :cond_0

    instance-of v2, v0, Lcom/redmadrobot/inputmask/model/state/FreeState;

    if-nez v2, :cond_0

    instance-of v2, v0, Lcom/redmadrobot/inputmask/model/state/ValueState;

    if-eqz v2, :cond_1

    :cond_0
    add-int/lit8 v1, v1, 0x1

    .line 217
    :cond_1
    invoke-virtual {v0}, Lcom/redmadrobot/inputmask/model/State;->getChild()Lcom/redmadrobot/inputmask/model/State;

    move-result-object v0

    goto :goto_0

    :cond_2
    return v1
.end method

.method public final acceptableValueLength()I
    .locals 3

    .line 248
    iget-object v0, p0, Lcom/redmadrobot/inputmask/helper/Mask;->initialState:Lcom/redmadrobot/inputmask/model/State;

    const/4 v1, 0x0

    :goto_0
    if-eqz v0, :cond_2

    .line 251
    instance-of v2, v0, Lcom/redmadrobot/inputmask/model/state/EOLState;

    if-nez v2, :cond_2

    .line 252
    instance-of v2, v0, Lcom/redmadrobot/inputmask/model/state/FixedState;

    if-nez v2, :cond_0

    instance-of v2, v0, Lcom/redmadrobot/inputmask/model/state/ValueState;

    if-eqz v2, :cond_1

    :cond_0
    add-int/lit8 v1, v1, 0x1

    .line 255
    :cond_1
    invoke-virtual {v0}, Lcom/redmadrobot/inputmask/model/State;->getChild()Lcom/redmadrobot/inputmask/model/State;

    move-result-object v0

    goto :goto_0

    :cond_2
    return v1
.end method

.method public apply(Lcom/redmadrobot/inputmask/model/CaretString;)Lcom/redmadrobot/inputmask/helper/Mask$Result;
    .locals 13

    const-string v0, "text"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkParameterIsNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    .line 113
    invoke-virtual {p0, p1}, Lcom/redmadrobot/inputmask/helper/Mask;->makeIterator(Lcom/redmadrobot/inputmask/model/CaretString;)Lcom/redmadrobot/inputmask/helper/CaretStringIterator;

    move-result-object v0

    .line 118
    invoke-virtual {p1}, Lcom/redmadrobot/inputmask/model/CaretString;->getCaretPosition()I

    move-result v1

    .line 120
    iget-object v2, p0, Lcom/redmadrobot/inputmask/helper/Mask;->initialState:Lcom/redmadrobot/inputmask/model/State;

    .line 121
    new-instance v3, Lcom/redmadrobot/inputmask/helper/Mask$AutocompletionStack;

    invoke-direct {v3}, Lcom/redmadrobot/inputmask/helper/Mask$AutocompletionStack;-><init>()V

    .line 123
    invoke-virtual {v0}, Lcom/redmadrobot/inputmask/helper/CaretStringIterator;->insertionAffectsCaret()Z

    move-result v4

    .line 124
    invoke-virtual {v0}, Lcom/redmadrobot/inputmask/helper/CaretStringIterator;->deletionAffectsCaret()Z

    move-result v5

    .line 125
    invoke-virtual {v0}, Lcom/redmadrobot/inputmask/helper/CaretStringIterator;->next()Ljava/lang/Character;

    move-result-object v6

    const/4 v7, 0x0

    const-string v8, ""

    move-object v9, v8

    move-object v10, v9

    :goto_0
    if-eqz v6, :cond_7

    .line 128
    invoke-virtual {v6}, Ljava/lang/Character;->charValue()C

    move-result v11

    invoke-virtual {v2, v11}, Lcom/redmadrobot/inputmask/model/State;->accept(C)Lcom/redmadrobot/inputmask/model/Next;

    move-result-object v11

    if-eqz v11, :cond_5

    if-eqz v5, :cond_0

    .line 130
    invoke-virtual {v2}, Lcom/redmadrobot/inputmask/model/State;->autocomplete()Lcom/redmadrobot/inputmask/model/Next;

    move-result-object v2

    invoke-virtual {v3, v2}, Lcom/redmadrobot/inputmask/helper/Mask$AutocompletionStack;->push(Lcom/redmadrobot/inputmask/model/Next;)Lcom/redmadrobot/inputmask/model/Next;

    .line 131
    :cond_0
    invoke-virtual {v11}, Lcom/redmadrobot/inputmask/model/Next;->getState()Lcom/redmadrobot/inputmask/model/State;

    move-result-object v2

    .line 132
    new-instance v12, Ljava/lang/StringBuilder;

    invoke-direct {v12}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v12, v9}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v11}, Lcom/redmadrobot/inputmask/model/Next;->getInsert()Ljava/lang/Character;

    move-result-object v9

    if-eqz v9, :cond_1

    goto :goto_1

    :cond_1
    move-object v9, v8

    :goto_1
    invoke-virtual {v12, v9}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    invoke-virtual {v12}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v9

    .line 133
    new-instance v12, Ljava/lang/StringBuilder;

    invoke-direct {v12}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v12, v10}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v11}, Lcom/redmadrobot/inputmask/model/Next;->getValue()Ljava/lang/Character;

    move-result-object v10

    if-eqz v10, :cond_2

    goto :goto_2

    :cond_2
    move-object v10, v8

    :goto_2
    invoke-virtual {v12, v10}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    invoke-virtual {v12}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v10

    .line 134
    invoke-virtual {v11}, Lcom/redmadrobot/inputmask/model/Next;->getPass()Z

    move-result v12

    if-eqz v12, :cond_3

    .line 135
    invoke-virtual {v0}, Lcom/redmadrobot/inputmask/helper/CaretStringIterator;->insertionAffectsCaret()Z

    move-result v4

    .line 136
    invoke-virtual {v0}, Lcom/redmadrobot/inputmask/helper/CaretStringIterator;->deletionAffectsCaret()Z

    move-result v5

    .line 137
    invoke-virtual {v0}, Lcom/redmadrobot/inputmask/helper/CaretStringIterator;->next()Ljava/lang/Character;

    move-result-object v6

    add-int/lit8 v7, v7, 0x1

    goto :goto_0

    :cond_3
    if-eqz v4, :cond_4

    .line 140
    invoke-virtual {v11}, Lcom/redmadrobot/inputmask/model/Next;->getInsert()Ljava/lang/Character;

    move-result-object v11

    if-eqz v11, :cond_4

    add-int/lit8 v1, v1, 0x1

    :cond_4
    :goto_3
    add-int/lit8 v7, v7, -0x1

    goto :goto_0

    :cond_5
    if-eqz v5, :cond_6

    add-int/lit8 v1, v1, -0x1

    .line 149
    :cond_6
    invoke-virtual {v0}, Lcom/redmadrobot/inputmask/helper/CaretStringIterator;->insertionAffectsCaret()Z

    move-result v4

    .line 150
    invoke-virtual {v0}, Lcom/redmadrobot/inputmask/helper/CaretStringIterator;->deletionAffectsCaret()Z

    move-result v5

    .line 151
    invoke-virtual {v0}, Lcom/redmadrobot/inputmask/helper/CaretStringIterator;->next()Ljava/lang/Character;

    move-result-object v6

    goto :goto_3

    .line 156
    :cond_7
    :goto_4
    invoke-virtual {p1}, Lcom/redmadrobot/inputmask/model/CaretString;->getCaretGravity()Lcom/redmadrobot/inputmask/model/CaretString$CaretGravity;

    move-result-object v0

    invoke-virtual {v0}, Lcom/redmadrobot/inputmask/model/CaretString$CaretGravity;->getAutocomplete()Z

    move-result v0

    if-eqz v0, :cond_a

    if-eqz v4, :cond_a

    .line 157
    invoke-virtual {v2}, Lcom/redmadrobot/inputmask/model/State;->autocomplete()Lcom/redmadrobot/inputmask/model/Next;

    move-result-object v0

    if-eqz v0, :cond_a

    .line 158
    invoke-virtual {v0}, Lcom/redmadrobot/inputmask/model/Next;->getState()Lcom/redmadrobot/inputmask/model/State;

    move-result-object v2

    .line 159
    new-instance v5, Ljava/lang/StringBuilder;

    invoke-direct {v5}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v5, v9}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v0}, Lcom/redmadrobot/inputmask/model/Next;->getInsert()Ljava/lang/Character;

    move-result-object v6

    if-eqz v6, :cond_8

    goto :goto_5

    :cond_8
    move-object v6, v8

    :goto_5
    invoke-virtual {v5, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    invoke-virtual {v5}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v9

    .line 160
    new-instance v5, Ljava/lang/StringBuilder;

    invoke-direct {v5}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v5, v10}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v0}, Lcom/redmadrobot/inputmask/model/Next;->getValue()Ljava/lang/Character;

    move-result-object v6

    if-eqz v6, :cond_9

    goto :goto_6

    :cond_9
    move-object v6, v8

    :goto_6
    invoke-virtual {v5, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    invoke-virtual {v5}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v10

    .line 161
    invoke-virtual {v0}, Lcom/redmadrobot/inputmask/model/Next;->getInsert()Ljava/lang/Character;

    move-result-object v0

    if-eqz v0, :cond_7

    add-int/lit8 v1, v1, 0x1

    goto :goto_4

    .line 166
    :cond_a
    :goto_7
    invoke-virtual {p1}, Lcom/redmadrobot/inputmask/model/CaretString;->getCaretGravity()Lcom/redmadrobot/inputmask/model/CaretString$CaretGravity;

    move-result-object v0

    invoke-virtual {v0}, Lcom/redmadrobot/inputmask/model/CaretString$CaretGravity;->getAutoskip()Z

    move-result v0

    if-eqz v0, :cond_f

    invoke-virtual {v3}, Ljava/util/Stack;->empty()Z

    move-result v0

    if-nez v0, :cond_f

    .line 167
    invoke-virtual {v3}, Ljava/util/Stack;->pop()Ljava/lang/Object;

    move-result-object v0

    const-string v4, "autocompletionStack.pop()"

    invoke-static {v0, v4}, Lkotlin/jvm/internal/Intrinsics;->checkExpressionValueIsNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    check-cast v0, Lcom/redmadrobot/inputmask/model/Next;

    .line 168
    invoke-virtual {v9}, Ljava/lang/String;->length()I

    move-result v4

    if-ne v4, v1, :cond_e

    .line 169
    invoke-virtual {v0}, Lcom/redmadrobot/inputmask/model/Next;->getInsert()Ljava/lang/Character;

    move-result-object v4

    const/4 v5, 0x1

    if-eqz v4, :cond_c

    invoke-virtual {v0}, Lcom/redmadrobot/inputmask/model/Next;->getInsert()Ljava/lang/Character;

    move-result-object v4

    invoke-static {v9}, Lcom/scanflow/datacapture/barinternal/kotlin/text/StringsKt;->last(Ljava/lang/CharSequence;)C

    move-result v6

    if-nez v4, :cond_b

    goto :goto_8

    :cond_b
    invoke-virtual {v4}, Ljava/lang/Character;->charValue()C

    move-result v4

    if-ne v4, v6, :cond_c

    .line 170
    invoke-static {v9, v5}, Lcom/scanflow/datacapture/barinternal/kotlin/text/StringsKt;->dropLast(Ljava/lang/String;I)Ljava/lang/String;

    move-result-object v9

    add-int/lit8 v1, v1, -0x1

    .line 173
    :cond_c
    :goto_8
    invoke-virtual {v0}, Lcom/redmadrobot/inputmask/model/Next;->getValue()Ljava/lang/Character;

    move-result-object v4

    if-eqz v4, :cond_a

    invoke-virtual {v0}, Lcom/redmadrobot/inputmask/model/Next;->getValue()Ljava/lang/Character;

    move-result-object v0

    invoke-static {v10}, Lcom/scanflow/datacapture/barinternal/kotlin/text/StringsKt;->last(Ljava/lang/CharSequence;)C

    move-result v4

    if-nez v0, :cond_d

    goto :goto_7

    :cond_d
    invoke-virtual {v0}, Ljava/lang/Character;->charValue()C

    move-result v0

    if-ne v0, v4, :cond_a

    .line 174
    invoke-static {v10, v5}, Lcom/scanflow/datacapture/barinternal/kotlin/text/StringsKt;->dropLast(Ljava/lang/String;I)Ljava/lang/String;

    move-result-object v0

    move-object v10, v0

    goto :goto_7

    .line 177
    :cond_e
    invoke-virtual {v0}, Lcom/redmadrobot/inputmask/model/Next;->getInsert()Ljava/lang/Character;

    move-result-object v0

    if-eqz v0, :cond_a

    add-int/lit8 v1, v1, -0x1

    goto :goto_7

    .line 183
    :cond_f
    new-instance v0, Lcom/redmadrobot/inputmask/helper/Mask$Result;

    .line 184
    new-instance v3, Lcom/redmadrobot/inputmask/model/CaretString;

    .line 187
    invoke-virtual {p1}, Lcom/redmadrobot/inputmask/model/CaretString;->getCaretGravity()Lcom/redmadrobot/inputmask/model/CaretString$CaretGravity;

    move-result-object p1

    .line 184
    invoke-direct {v3, v9, v1, p1}, Lcom/redmadrobot/inputmask/model/CaretString;-><init>(Ljava/lang/String;ILcom/redmadrobot/inputmask/model/CaretString$CaretGravity;)V

    .line 191
    invoke-direct {p0, v2}, Lcom/redmadrobot/inputmask/helper/Mask;->noMandatoryCharactersLeftAfterState(Lcom/redmadrobot/inputmask/model/State;)Z

    move-result p1

    .line 183
    invoke-direct {v0, v3, v10, v7, p1}, Lcom/redmadrobot/inputmask/helper/Mask$Result;-><init>(Lcom/redmadrobot/inputmask/model/CaretString;Ljava/lang/String;IZ)V

    return-object v0
.end method

.method protected final getCustomNotations()Ljava/util/List;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/List<",
            "Lcom/redmadrobot/inputmask/model/Notation;",
            ">;"
        }
    .end annotation

    .line 23
    iget-object v0, p0, Lcom/redmadrobot/inputmask/helper/Mask;->customNotations:Ljava/util/List;

    return-object v0
.end method

.method public makeIterator(Lcom/redmadrobot/inputmask/model/CaretString;)Lcom/redmadrobot/inputmask/helper/CaretStringIterator;
    .locals 4

    const-string v0, "text"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkParameterIsNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    .line 195
    new-instance v0, Lcom/redmadrobot/inputmask/helper/CaretStringIterator;

    const/4 v1, 0x2

    const/4 v2, 0x0

    const/4 v3, 0x0

    invoke-direct {v0, p1, v3, v1, v2}, Lcom/redmadrobot/inputmask/helper/CaretStringIterator;-><init>(Lcom/redmadrobot/inputmask/model/CaretString;IILkotlin/jvm/internal/DefaultConstructorMarker;)V

    return-object v0
.end method

.method public final placeholder()Ljava/lang/String;
    .locals 2

    .line 202
    iget-object v0, p0, Lcom/redmadrobot/inputmask/helper/Mask;->initialState:Lcom/redmadrobot/inputmask/model/State;

    const-string v1, ""

    invoke-direct {p0, v0, v1}, Lcom/redmadrobot/inputmask/helper/Mask;->appendPlaceholder(Lcom/redmadrobot/inputmask/model/State;Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method public final totalTextLength()I
    .locals 3

    .line 229
    iget-object v0, p0, Lcom/redmadrobot/inputmask/helper/Mask;->initialState:Lcom/redmadrobot/inputmask/model/State;

    const/4 v1, 0x0

    :goto_0
    if-eqz v0, :cond_2

    .line 232
    instance-of v2, v0, Lcom/redmadrobot/inputmask/model/state/EOLState;

    if-nez v2, :cond_2

    .line 233
    instance-of v2, v0, Lcom/redmadrobot/inputmask/model/state/FixedState;

    if-nez v2, :cond_0

    instance-of v2, v0, Lcom/redmadrobot/inputmask/model/state/FreeState;

    if-nez v2, :cond_0

    instance-of v2, v0, Lcom/redmadrobot/inputmask/model/state/ValueState;

    if-nez v2, :cond_0

    instance-of v2, v0, Lcom/redmadrobot/inputmask/model/state/OptionalValueState;

    if-eqz v2, :cond_1

    :cond_0
    add-int/lit8 v1, v1, 0x1

    .line 236
    :cond_1
    invoke-virtual {v0}, Lcom/redmadrobot/inputmask/model/State;->getChild()Lcom/redmadrobot/inputmask/model/State;

    move-result-object v0

    goto :goto_0

    :cond_2
    return v1
.end method

.method public final totalValueLength()I
    .locals 3

    .line 267
    iget-object v0, p0, Lcom/redmadrobot/inputmask/helper/Mask;->initialState:Lcom/redmadrobot/inputmask/model/State;

    const/4 v1, 0x0

    :goto_0
    if-eqz v0, :cond_2

    .line 270
    instance-of v2, v0, Lcom/redmadrobot/inputmask/model/state/EOLState;

    if-nez v2, :cond_2

    .line 271
    instance-of v2, v0, Lcom/redmadrobot/inputmask/model/state/FixedState;

    if-nez v2, :cond_0

    instance-of v2, v0, Lcom/redmadrobot/inputmask/model/state/ValueState;

    if-nez v2, :cond_0

    instance-of v2, v0, Lcom/redmadrobot/inputmask/model/state/OptionalValueState;

    if-eqz v2, :cond_1

    :cond_0
    add-int/lit8 v1, v1, 0x1

    .line 274
    :cond_1
    invoke-virtual {v0}, Lcom/redmadrobot/inputmask/model/State;->getChild()Lcom/redmadrobot/inputmask/model/State;

    move-result-object v0

    goto :goto_0

    :cond_2
    return v1
.end method
