.class public final Lcom/scanflow/datacapture/barinternal/kotlin/Unit;
.super Ljava/lang/Object;
.source "Unit.kt"


# static fields
.field public static final INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlin/Unit;


# direct methods
.method static constructor <clinit>()V
    .locals 1

    .line 0
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlin/Unit;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/Unit;-><init>()V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/Unit;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlin/Unit;

    return-void
.end method

.method private constructor <init>()V
    .locals 0

    .line 13
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public toString()Ljava/lang/String;
    .locals 1

    .line 14
    const-string v0, "kotlin.Unit"

    return-object v0
.end method
