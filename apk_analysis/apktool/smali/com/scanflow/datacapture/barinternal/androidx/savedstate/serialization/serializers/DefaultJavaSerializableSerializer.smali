.class public final Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/DefaultJavaSerializableSerializer;
.super Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/JavaSerializableSerializer;
.source "BuiltInSerializer.android.kt"


# static fields
.field public static final INSTANCE:Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/DefaultJavaSerializableSerializer;


# direct methods
.method static constructor <clinit>()V
    .locals 1

    .line 0
    new-instance v0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/DefaultJavaSerializableSerializer;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/DefaultJavaSerializableSerializer;-><init>()V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/DefaultJavaSerializableSerializer;->INSTANCE:Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/DefaultJavaSerializableSerializer;

    return-void
.end method

.method private constructor <init>()V
    .locals 0

    .line 129
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/androidx/savedstate/serialization/serializers/JavaSerializableSerializer;-><init>()V

    return-void
.end method
