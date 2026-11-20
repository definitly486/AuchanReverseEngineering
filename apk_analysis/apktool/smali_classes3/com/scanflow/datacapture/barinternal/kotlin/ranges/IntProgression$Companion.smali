.class public final Lcom/scanflow/datacapture/barinternal/kotlin/ranges/IntProgression$Companion;
.super Ljava/lang/Object;
.source "Progressions.kt"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/scanflow/datacapture/barinternal/kotlin/ranges/IntProgression;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x19
    name = "Companion"
.end annotation


# direct methods
.method private constructor <init>()V
    .locals 0

    .line 125
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method

.method public synthetic constructor <init>(Lkotlin/jvm/internal/DefaultConstructorMarker;)V
    .locals 0

    .line 0
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/ranges/IntProgression$Companion;-><init>()V

    return-void
.end method


# virtual methods
.method public final fromClosedRange(III)Lcom/scanflow/datacapture/barinternal/kotlin/ranges/IntProgression;
    .locals 1

    .line 134
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlin/ranges/IntProgression;

    invoke-direct {v0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/kotlin/ranges/IntProgression;-><init>(III)V

    return-object v0
.end method
